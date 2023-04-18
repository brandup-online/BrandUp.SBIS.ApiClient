using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.Base.Attributes;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.EDM
{
    internal class EDMSerializer : ISerializer
    {
        readonly JsonSerializerOptions options;
        public EDMSerializer(JsonSerializerOptions options = null)
        {
            this.options = options ?? new JsonSerializerOptions();
        }

        public async Task<Stream> SerializeAsync<T>(T content, CancellationToken cancellationToken)
        {
            var ms = new MemoryStream();
            await JsonSerializer.SerializeAsync<JsonRpcRequest>(ms, new(content), options, cancellationToken);
            return ms;
        }

        public async Task<T> DeserializeAsync<T>(Stream content, CancellationToken cancellationToken)
        {
            var response = await JsonSerializer.DeserializeAsync<JsonRpcResponse<T>>(content, options, cancellationToken);
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


        private class ParametersConverter : JsonConverter<Parameters>
        {
            public override Parameters Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override void Write(Utf8JsonWriter writer, Parameters value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                var root = value.Object.GetType().GetCustomAttribute<RpcCommandInfoAttribute>().RootName;
                writer.WritePropertyName(root);
                JsonSerializer.Serialize(writer, value.Object, options);
                writer.WriteEndObject();
            }
        }

        private class JsonRpcResponse<T>
        {
            public string Jsonrpc { get; set; }
            public string Method { get; set; }
            public Error Error { get; set; }
            [JsonPropertyName("params")]
            public T Result { get; set; }
        }

        private class Error
        {
            public int? Code { get; set; }
            public string Message { get; set; }
            public string Data { get; set; }
        }

        #endregion
    }


}
