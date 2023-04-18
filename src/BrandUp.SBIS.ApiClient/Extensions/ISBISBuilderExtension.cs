using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.EDM;
using Microsoft.Extensions.DependencyInjection;

namespace BrandUp.SBIS.ApiClient
{
    public static class ISBISBuilderExtension
    {
        public static ISBISBuilder AddSBIS(this IServiceCollection services)
        {
            return new SBISBuilder(services);
        }

        public static ISBISBuilder AddApiCredentials(this ISBISBuilder builder, Action<BaseCredentials> options)
        {
            builder.Services.AddOptions<BaseCredentials>().Configure(options);
            return builder;
        }

        public static ISBISBuilder AddEDMCredentials(this ISBISBuilder builder, Action<EDMCredentials> options)
        {
            builder.Services.AddOptions<EDMCredentials>().Configure(options);
            return builder;
        }
    }
}
