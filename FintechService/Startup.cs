using Autofac;
using Autofac.Extensions.DependencyInjection;
using FintechService.ApplicationService;
using FintechService.Container;
using FintechService.Container.Modules;
using FintechService.Request.Command;
using FintechService.Request.Query;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;

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
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //add service for httpContext            
            services.AddControllers();
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<ValidationFilter>();
            });
            services.AddMediatR(typeof(GetCustomerQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateCustomerCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteCustomerCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateCustomerCommand).GetTypeInfo().Assembly);



            services.AddLocalization();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fintech API",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact()
                    {
                        Email = "denizbati5@gmail.com",
                        Name = "Deniz Batı"
                    }
                });
                c.CustomSchemaIds(type => type.ToString());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });

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

            var container = app.ApplicationServices.GetAutofacRoot();
            Bootstrapper.SetContainer(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/error");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment API");

                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

                c.EnableDeepLinking();
                //c.DisplayOperationId();
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Bootstrapper.RegisterModules(builder);
        }
    
}
}




