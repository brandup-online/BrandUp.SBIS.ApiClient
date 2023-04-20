using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.EDM.Credetials;
using Microsoft.Extensions.DependencyInjection;

namespace BrandUp.SBIS.ApiClient
{
    public static class ISBISBuilderExtension
    {
        public static ISBISBuilder AddSBIS(this IServiceCollection services)
        {
            return new SBISBuilder(services);
        }

        public static ISBISBuilder AddApiCredentials(this ISBISBuilder builder, Action<ServiceCredentials> options)
        {
            builder.Services.AddOptions<ServiceCredentials>().Configure(options);
            return builder;
        }

        public static ISBISBuilder AddEDMCredentials(this ISBISBuilder builder, Action<EDMCredentials> options)
        {
            builder.Services.AddOptions<EDMCredentials>().Configure(options);
            return builder;
        }
    }
}
