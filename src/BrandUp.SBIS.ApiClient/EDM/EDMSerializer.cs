using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM
{
    internal class EDMSerializer : ISerializer
    {
        readonly static Encoding encoding = Encoding.GetEncoding("windows-1251");
        readonly JsonSerializerOptions options;
        public EDMSerializer(JsonSerializerOptions options = null)
        {
            this.options = options ?? new JsonSerializerOptions();
            this.options.Converters.Add(new BoolConverter());
            this.options.Converters.Add(new DateTimeConverter());
        }

        public async Task<Stream> SerializeAsync<T>(T content, CancellationToken cancellationToken)
        {
            var ms = new MemoryStream();
            await JsonSerializer.SerializeAsync<JsonRpcRequest>(ms, new(content), options, cancellationToken);
            return ms;
        }

        public async Task<T> DeserializeAsync<T>(Stream content, CancellationToken cancellationToken)
        {
            using var reader = new StreamReader(content, encoding);
            var data = await reader.ReadToEndAsync(cancellationToken);
            var bytes = Encoding.Convert(encoding, Encoding.UTF8, encoding.GetBytes(data));

            using var utf8Stream = new MemoryStream(bytes);
            var response = await JsonSerializer.DeserializeAsync<JsonRpcResponse<T>>(utf8Stream, options, cancellationToken);
            return response.Result;
        }

        #region Helper classes

        private class JsonRpcRequest
        {
            public string Jsonrpc { get; set; } = "2.0";
            public string Method { get; set; }
            [JsonConverter(typeof(ParametersConverter)), JsonPropertyName("params")]
            public Parameters Parameters { get; set; }
            public string Id { get; set; } = "0";

            public JsonRpcRequest(object content)
            {
                Method = content.GetType().GetCustomAttribute<RpcCommandInfoAttribute>()?.Command ?? throw new ArgumentException("Method");
                if (content == null)
                    throw new ArgumentNullException(nameof(content));
                Parameters = new Parameters { Object = content };
            }
        }

        private class Parameters
        {
            public object Object { get; set; }
        }


        private class JsonRpcResponse<T>
        {
            public string Jsonrpc { get; set; }
            public Error Error { get; set; }
            [JsonPropertyName("result")]
            public T Result { get; set; }
            public string Id { get; set; }
        }

        private class Error
        {
            public int? Code { get; set; }
            public string Message { get; set; }
            public string Data { get; set; }
        }


        private class ParametersConverter : JsonConverter<Parameters>
        {
            public override Parameters Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override void Write(Utf8JsonWriter writer, Parameters value, JsonSerializerOptions options)
            {
                var root = value.Object.GetType().GetCustomAttribute<RpcCommandInfoAttribute>().RootName;
                if (root == null)
                {
                    JsonSerializer.Serialize(writer, value.Object, options);
                    return;
                }
                writer.WriteStartObject();
                writer.WritePropertyName(root);
                JsonSerializer.Serialize(writer, value.Object, options);
                writer.WriteEndObject();
            }
        }

        class BoolConverter : JsonConverter<bool?>
        {
            public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var data = reader.GetString();
                data = data?.Trim().ToLowerInvariant();

                if (string.IsNullOrEmpty(data))
                    throw null;

                if (bool.TryParse(data, out bool result))
                    return result;

                if (data == "да")
                    return true;
                if (data == "нет")
                    return false;
                throw null;
            }

            public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
            {
                if (value.HasValue)
                    if (value.Value)
                    {
                        writer.WriteStringValue("Да");
                    }
                    else
                    {
                        writer.WriteStringValue("Нет");
                    }
            }
        }

        class DateTimeConverter : JsonConverter<DateTime?>
        {
            public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (!reader.TryGetDateTime(out var dateTime))
                {
                    var raw = Encoding.UTF8.GetString(reader.ValueSpan);
                    if (string.IsNullOrEmpty(raw))
                        return null;

                    var array = raw.Trim().Replace(' ', '.').Split('.').Select(s => int.Parse(s)).ToArray();
                    if (array.Length == 3)
                        return new DateTime(array[2], array[1], array[0]);
                    else if (array.Length == 6)
                        return new DateTime(array[2], array[1], array[0], array[3], array[4], array[5]);
                    else throw new ArgumentException(nameof(reader));
                }

                return dateTime;
            }

            public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.Value.ToString() ?? " ");
            }
        }

        #endregion
    }
}
