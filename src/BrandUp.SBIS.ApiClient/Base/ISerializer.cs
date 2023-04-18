using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.Base
{
    internal interface ISerializer
    {
        Task<Stream> SerializeAsync<T>(T content, CancellationToken cancellationToken);
        Task<T> DeserializeAsync<T>(Stream content, CancellationToken cancellationToken);
    }

    internal class DefaultSerializer : ISerializer
    {
        readonly JsonSerializerOptions options;

        public DefaultSerializer(JsonSerializerOptions options)
        {
            this.options = options ?? new();
        }

        public async Task<T> DeserializeAsync<T>(Stream content, CancellationToken cancellationToken)
        {
            return await JsonSerializer.DeserializeAsync<T>(content, options, cancellationToken);
        }

        public async Task<Stream> SerializeAsync<T>(T content, CancellationToken cancellationToken)
        {
            var ms = new MemoryStream();

            await JsonSerializer.SerializeAsync<T>(ms, content, options, cancellationToken);

            return ms;
        }
    }
}
