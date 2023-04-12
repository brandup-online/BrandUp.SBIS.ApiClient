using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BrandUp.SBIS.ApiClient
{
    public abstract class TestBase : IAsyncLifetime
    {
        readonly ServiceProvider rootServiceProvider;
        readonly IServiceScope serviceScope;
        readonly IConfiguration configuration;

        public IServiceProvider RootServices => rootServiceProvider;
        public IServiceProvider Services => serviceScope.ServiceProvider;
        public IConfiguration Configuration => configuration;

        public TestBase()
        {
            var services = new ServiceCollection();

            var configBuilder = new ConfigurationBuilder()
            .AddUserSecrets(typeof(TestBase).Assembly)
            .AddJsonFile("appsettings.test.json", true);

            configuration = configBuilder.Build();

            services.AddLogging(builder => builder.AddDebug());

            services.AddSBISClient(options => configuration.GetSection("Creds").Bind(options));

            rootServiceProvider = services.BuildServiceProvider();
            serviceScope = rootServiceProvider.CreateScope();
        }

        #region IAsyncLifetime members

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            await rootServiceProvider.DisposeAsync();
            serviceScope.Dispose();
        }

        #endregion
    }
}
