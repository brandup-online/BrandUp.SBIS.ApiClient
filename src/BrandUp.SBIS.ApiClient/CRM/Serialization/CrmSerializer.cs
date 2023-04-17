using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Serialization
{
    internal class CrmSerializer : ISerializer
    {
        readonly static JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };
        readonly static Encoding encoding = Encoding.GetEncoding("windows-1251");

        static CrmSerializer()
        {
            options.Converters.Add(new DateTimeConverter());
        }

        public Task<Stream> SerializeAsync<T>(T content, CancellationToken cancellationToken)
             => SerializeAsync(content, typeof(T), cancellationToken);

        public static Task<Stream> SerializeAsync(object content, Type contentType, CancellationToken cancellationToken)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));

            if (cancellationToken.IsCancellationRequested)
                throw new TaskCanceledException();

            var body = SerializeBody(content, contentType);

            //var body = JsonNode.Parse("{\"НаименованиеТемы\": \"Пример_названия\"}");

            MemoryStream ms = new();
            using Utf8JsonWriter writer = new(ms);

            body.WriteTo(writer);

            writer.Flush();
            ms.Seek(0, SeekOrigin.Begin);

            return Task.FromResult<Stream>(ms);
        }

        public async Task<T> DeserializeAsync<T>(Stream content, CancellationToken cancellationToken)
        => (T)(await DeserializeAsync(content, typeof(T), cancellationToken));

        public static async Task<object> DeserializeAsync(Stream content, Type contentType, CancellationToken cancellationToken)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));

            using var reader = new StreamReader(content, encoding);
            var data = await reader.ReadToEndAsync(cancellationToken);
            var json = JsonNode.Parse(data);

            if (!IsValid(json))
                throw new NotSupportedException();

            return DeserializeToObject(json.AsObject(), contentType);
        }

        private static bool IsValid(JsonNode json)
        {
            if (json == null)
                return false;
            if (json["result"] == null)
                return false;
            var root = json["result"];

            if (root is JsonValue)
                return true;
            if (root["d"] == null && root["s"] == null)
                return false;

            return true;
        }


        #region Serialization helpers

        static JsonObject SerializeBody(object content, Type contentType)
        {
            var attribute = contentType.GetCustomAttribute<CrmRpcCommandInfoAttribute>();
            if (attribute == null)
                return null;

            return new JsonObject
            {
                ["jsonrpc"] = "2.0",
                ["method"] = attribute.Command,
                ["params"] = SerializeObject(attribute.RootName, contentType.GetProperties(), attribute.WithOptions, content)
            };
        }

        static JsonObject SerializeObject(string rootName, PropertyInfo[] properties, bool optionsFlag, object content)
        {
            var json = CreateJsonObject(rootName);

            if (optionsFlag)
                json.Add("options", null);

            JsonNode rootNode = json;
            if (rootName != null)
                rootNode = json[rootName];
            FillNode(rootNode, properties, content);

            return json;
        }

        static void FillNode(JsonNode node, PropertyInfo[] properties, object obj = null)
        {
            foreach (var prop in properties)
            {
                var (value, type) = Convert(prop, obj);
                if (value != null && type != null)
                {
                    node["d"].AsObject().Add(Name(prop), value);
                    node["s"].AsObject().Add(Name(prop), type);
                }
            }
        }

        static (JsonNode, string) Convert(PropertyInfo property, object content)
        {
            var type = property.PropertyType;
            if (IsNullable(type))
            {
                type = type.GetGenericArguments()[0];
            }

            var value = property.GetValue(content);
            if (value == null)
                return (null, null);

            if (type == typeof(int))
                return (JsonValue.Create((int)value), "Число целое");
            if (type == typeof(long))
                return (JsonValue.Create((long)value), "Число целое");
            if (type == typeof(Guid))
                return (JsonValue.Create((Guid)property.GetValue(content)), "UUID");
            if (type == typeof(string))
                return (JsonValue.Create((string)property.GetValue(content)), "Строка");
            if (type == typeof(bool))
                return (JsonValue.Create((bool)property.GetValue(content)), "Логическое");
            if (type == typeof(DateTime))
                return (JsonValue.Create((DateTime)property.GetValue(content)), "Дата и время");

            if (type.IsAssignableFrom(typeof(IEnumerable)))
            {
                var array = new JsonArray();
                var itemProperties = type.GetGenericArguments()[0].GetProperties();
                foreach (var item in (IEnumerable)property.GetValue(content))
                {
                    var innerObject = CreateInnerJsonObject();
                    FillNode(innerObject, itemProperties, item);
                    array.Add(innerObject);
                }
                return (array, "Выборка");
            }

            if (!type.IsSerializable)
            {
                var dataObj = property.GetValue(content);
                var node = SerializeObject(null, property.PropertyType.GetProperties(), false, dataObj);

                return (node, "Запись");
            }

            throw new ArgumentException($"Unesxpected type: {property.PropertyType}", nameof(property));
        }

        #endregion

        #region Deserialization helpers

        static object DeserializeToObject(JsonObject json, Type objectType)
        {
            var instance = CreateInstance(objectType);

            var result = json["result"];
            if (result is JsonValue value)
            {
                FromValue(value, ref instance);
            }
            else if (result["d"] is JsonArray)
            {
                FromArray(result, ref instance);
            }
            else if (result["d"] is JsonObject obj)
            {
                FromObject(obj, ref instance);
            }
            else throw new NotSupportedException();

            return instance;
        }

        private static void FromArray(JsonNode node, ref object instance)
        {
            var type = instance.GetType();
            var signatures = node["s"]?.AsArray() ?? throw new ArgumentException(null, nameof(node));

            if (type.GetProperties().Length == 1)
            {
                var listType = type.GetProperties()[0].PropertyType;
                if (listType.IsAssignableTo(typeof(IList)))
                {
                    var listInstance = (IList)CreateInstance(listType);
                    var genericType = listType.GenericTypeArguments.First();

                    foreach (var responses in node["d"].AsArray())
                    {
                        var definitions = responses as JsonArray ?? throw new ArgumentException(null, nameof(node));
                        var innerInstance = CreateInstance(genericType);
                        DeserializeArrayNode(definitions, signatures, ref innerInstance);
                        listInstance.Add(innerInstance);
                    }
                    type.GetProperties().First().SetValue(instance, listInstance);
                }
            }
            else
                DeserializeArrayNode(node["d"].AsArray().First().AsArray(), signatures, ref instance);
        }

        private static void FromObject(JsonObject obj, ref object instance)
            => instance = obj.Deserialize(instance.GetType(), options);

        private static void FromValue(JsonValue value, ref object instance)
        {
            var property = instance.GetType().GetProperties().Single();

            property.SetValue(instance, value.Deserialize(property.PropertyType));
        }

        static void DeserializeArrayNode(JsonArray definitionArray, JsonArray signaturesArray, ref object instance)
        {
            var type = instance.GetType();

            var array = definitionArray.Zip(signaturesArray, (d, s) => new { Value = d, Signature = s });

            foreach (var record in array)
            {
                var propertyName = record.Signature["n"].AsValue().GetValue<string>();
                var prop = GetPropertyByName(propertyName, type) ?? throw new Exception($"Unknown key: {propertyName}");
                if (record.Value is JsonValue value)
                {
                    prop.SetValue(instance, value.Deserialize(prop.PropertyType, options));
                }
                else if (record.Value is JsonObject obj)
                {
                    var innerObject = prop.PropertyType.GetConstructor(Type.EmptyTypes).Invoke(null);
                    FromObject(obj["d"].AsObject(), ref innerObject);
                    prop.SetValue(instance, innerObject);
                }
            }
        }

        static object CreateInstance(Type objectType)
        {
            var constructor = objectType.GetConstructor(Type.EmptyTypes) ?? throw new ArgumentException(null, nameof(objectType));

            return constructor.Invoke(null);
        }

        static PropertyInfo GetPropertyByName(string name, Type type)
        {
            foreach (var prop in type.GetProperties())
            {
                if (name == Name(prop))
                    return prop;
            }
            return null;
        }

        static JsonObject CreateJsonObject(string rootName)
        {
            if (rootName == null)
                return CreateInnerJsonObject();
            return new JsonObject
            {
                [rootName] = CreateInnerJsonObject()
            };
        }

        static JsonObject CreateInnerJsonObject()
        {
            return new JsonObject()
            {
                ["d"] = new JsonObject(),
                ["s"] = new JsonObject()
            };
        }

        #endregion

        #region Common helpers

        static string Name(MemberInfo member)
        {
            var propertyName = member.GetCustomAttribute<JsonPropertyNameAttribute>();

            return propertyName?.Name ?? member.Name;
        }

        static bool IsNullable(Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        #endregion
    }
}
