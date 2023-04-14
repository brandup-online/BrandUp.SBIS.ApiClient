using BrandUp.SBIS.ApiClient.Base;
using BrandUp.SBIS.ApiClient.Clients;
using BrandUp.SBIS.ApiClient.CRM;
using BrandUp.SBIS.ApiClient.EDM;
using Microsoft.Extensions.DependencyInjection;

namespace BrandUp.SBIS.ApiClient
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSBISClient(this IServiceCollection services, Action<Credentials> options)
        {
            services.AddOptions<Credentials>().Configure(options);
            services.AddHttpClient<ShopClient>(options =>
            {
                options.BaseAddress = new("https://api.sbis.ru/");
            });
            services.AddHttpClient<CRMClient>(options =>
            {
                options.BaseAddress = new("https://online.sbis.ru/service/");
            });
            services.AddHttpClient<EDMClient>(options =>
            {
                options.BaseAddress = new("https://online.sbis.ru/service/?srv=1");
            });
            return services;
        }
    }
}
