using BrandUp.SBIS.ApiClient.Base;
using System.Text.Json;

namespace BrandUp.SBIS.ApiClient.EDM
{
    internal class EDMSerializer : ISerializer
    {
        readonly JsonSerializerOptions options;
        public EDMSerializer(JsonSerializerOptions options = null)
        {
            this.options = options ?? new JsonSerializerOptions();
        }

        public Task<T> DeserializeAsync<T>(Stream content, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> SerializeAsync<T>(T content, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
