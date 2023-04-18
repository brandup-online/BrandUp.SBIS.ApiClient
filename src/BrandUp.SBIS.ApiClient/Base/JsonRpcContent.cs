using System.Net;
using System.Net.Http.Headers;

namespace BrandUp.SBIS.ApiClient.Base
{
    internal class JsonRpcContent<T> : HttpContent
    {
        readonly T content;
        readonly ISerializer serializer;

        private long contentLength;

        public JsonRpcContent(T content, ISerializer serializer)
        {
            this.content = content ?? throw new ArgumentNullException(nameof(content));
            this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));

            Headers.ContentType = MediaTypeHeaderValue.Parse("application/json-rpc");
        }

        #region HttpContent members

        /// <summary>
        /// This method calls only from <c>SerializeToStreamAsync(Stream stream, TransportContext context, CancellationToken cancellationToken)</c>
        /// so we can leave this method as it is.
        /// </summary>
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            throw new NotImplementedException();
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context, CancellationToken cancellationToken)
        {
            using var jsonStream = await serializer.SerializeAsync(content, cancellationToken);

            jsonStream.Seek(0, SeekOrigin.Begin);
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
