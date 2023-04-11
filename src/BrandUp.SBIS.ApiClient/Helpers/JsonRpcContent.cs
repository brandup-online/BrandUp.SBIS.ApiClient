using BrandUp.SBIS.ApiClient.CRM.Attributes;
using System.Collections;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Helpers
{
    internal class JsonRpcContent : HttpContent
    {
        readonly object content;
        readonly Type contentType;
        readonly JsonSerializerOptions options;

        private long contentLength;

        public JsonRpcContent(object content, Type contentType, JsonSerializerOptions options)
        {
            this.content = content ?? throw new ArgumentNullException(nameof(content));
            this.contentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
            this.options = options ?? throw new ArgumentNullException(nameof(options));

            Headers.ContentType = MediaTypeHeaderValue.Parse("application/json-rpc");
        }

        public static JsonRpcContent Create<T>(T content, JsonSerializerOptions options)
        {
            return new(content, typeof(T), options);
        }

        #region HttpContent members

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            using var jsonStream = await SerializeToRpcCommandAsync();

            await jsonStream.CopyToAsync(stream);
            contentLength = jsonStream.Length;
        }

        protected override bool TryComputeLength(out long length)
        {
            if (contentLength != 0)
            {
                length = contentLength;
                return true;
            }
            else
            {
                length = default;
                return false;
            }
        }

        #endregion

        #region Helpers 

        async Task<Stream> SerializeToRpcCommandAsync()
        {
            var contentBody = CreateBody();

            MemoryStream ms = new();
            using Utf8JsonWriter writer = new(ms);

            contentBody.WriteTo(writer, options);

            writer.Flush();
            await ms.FlushAsync();
            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        JsonObject CreateBody()
        {
            var attribute = contentType.GetCustomAttribute<RpcCommandInfoAttribute>();

            return new JsonObject
            {
                ["jsonrpc"] = "2.0",
                ["method"] = attribute.Command,
                ["params"] = SerializeObject(attribute.RootName, contentType.GetProperties())
            };
        }

        JsonObject SerializeObject(string rootName, PropertyInfo[] properties, object obj = null)
        {
            var content = obj ?? this.content;
            var json = CreateJsonObject(rootName);
            JsonNode rootNode = json;
            if (rootName != null)
                rootNode = json[rootName];
            FillNode(rootNode, properties, content);

            return json;
        }

        void FillNode(JsonNode node, PropertyInfo[] properties, object obj = null)
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

        (JsonNode, string) Convert(PropertyInfo property, object obj)
        {
            var type = property.PropertyType;
            if (IsNullable(type))
            {
                type = type.GetGenericArguments()[0];
            }

            var value = property.GetValue(obj);
            if (value == null)
                return (null, null);

            if (type == typeof(int))
                return (JsonValue.Create((int)value), "Число целое");
            if (type == typeof(long))
                return (JsonValue.Create((long)value), "Число целое");
            if (type == typeof(Guid))
                return (JsonValue.Create((Guid)property.GetValue(obj)), "UUID");
            if (type == typeof(string))
                return (JsonValue.Create((string)property.GetValue(obj)), "Строка");
            if (type == typeof(bool))
                return (JsonValue.Create((string)property.GetValue(obj)), "Логическое");

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
                var dataObj = property.GetValue(obj);
                var node = SerializeObject(Name(property), property.PropertyType.GetProperties(), dataObj);

                return (node, "Запись");
            }

            throw new ArgumentException($"Unesxpected type: {property.PropertyType}", nameof(property));
        }

        static string Name(MemberInfo member)
        {
            var propertyName = member.GetCustomAttribute<JsonPropertyNameAttribute>();

            return propertyName?.Name ?? member.Name;
        }

        static bool IsNullable(Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
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
    }
}
