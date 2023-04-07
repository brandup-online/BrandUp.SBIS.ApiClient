using BrandUp.SBIS.ApiClient.Options;
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

            return services;
        }
    }
}
