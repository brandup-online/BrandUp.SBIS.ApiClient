using BrandUp.SBIS.ApiClient.Clients;
using BrandUp.SBIS.ApiClient.CRM;
using BrandUp.SBIS.ApiClient.EDM;
using Microsoft.Extensions.DependencyInjection;

namespace BrandUp.SBIS.ApiClient.Base
{
    public class SBISBuilder : ISBISBuilder
    {
        readonly IServiceCollection services;
        public SBISBuilder(IServiceCollection services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
            InitClients();
        }

        public IServiceCollection Services => services;

        void InitClients()
        {
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
        }
    }

    public interface ISBISBuilder
    {
        public IServiceCollection Services { get; }
    }
}
