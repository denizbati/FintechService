using Autofac;
using Autofac.Extensions.DependencyInjection;
using FintechService.Container;
using FintechService.Container.Modules;

namespace FintechService
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var environmentNamePath = string.IsNullOrEmpty(environmentName) ? "" : environmentName + ".";
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentNamePath}json", optional: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RepositoryModule.AddDbContext(services, Configuration);


            var authenticationProviderKey = "Bearer";//“IdentityApiKey”;
           
           
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //add service for httpContext            
           

           
            services.AddLocalization();


            services.AddHttpClient("user").SetHandlerLifetime(TimeSpan.FromSeconds(20));

            services.AddHttpClient("fintech", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetSection("Urls")["Fintech_Api_Uri"]);
                c.Timeout = new TimeSpan(0, 0, 60);
                c.DefaultRequestHeaders.Clear();
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                };
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {

            var supportedCultures = new[] { "tr", "en" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
            localizationOptions.ApplyCurrentCultureToResponseHeaders = true;
            app.UseRequestLocalization(localizationOptions);

            var container = app.ApplicationServices.GetAutofacRoot();
            Bootstrapper.SetContainer(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/error");
   
            app.UseRouting();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Bootstrapper.RegisterModules(builder);
        }
    
}
}




