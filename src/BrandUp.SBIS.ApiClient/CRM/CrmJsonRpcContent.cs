using System.Net;
using System.Net.Http.Headers;

namespace BrandUp.SBIS.ApiClient.CRM.Serialization
{
    internal class CrmJsonRpcContent : HttpContent
    {
        readonly object content;
        readonly Type contentType;

        private long contentLength;

        public CrmJsonRpcContent(object content, Type contentType)
        {
            this.content = content ?? throw new ArgumentNullException(nameof(content));
            this.contentType = contentType ?? throw new ArgumentNullException(nameof(contentType));

            Headers.ContentType = MediaTypeHeaderValue.Parse("application/json-rpc");
        }

        public static CrmJsonRpcContent Create<T>(T content)
        {
            return new(content, typeof(T));
        }

        #region HttpContent members

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            throw new NotImplementedException();
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context, CancellationToken cancellationToken)
        {
            using var jsonStream = await CrmSerializer.SerializeAsync(content, contentType, cancellationToken);

            await jsonStream.CopyToAsync(stream, cancellationToken);
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
    }
}
