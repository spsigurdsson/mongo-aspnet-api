using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

namespace mongo_aspnet_api {
    public class Startup {
        public Startup (IHostingEnvironment env, IConfiguration config) {
            HostingEnvironment = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

                 Configuration = builder.Build();
        }

        public IHostingEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

            // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }

        public void ConfigureServices (IServiceCollection services) {
            if (HostingEnvironment.IsDevelopment ()) {
                // Development configuration
            } else {
                // Staging/Production configuration
            }

            services.Configure<Settings>(options =>
            {
                options.ConnectionString 
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database 
                    = Configuration.GetSection("MongoConnection:Database").Value;
            });


            services.AddSingleton<IMongoAsyncRepository<DateCounter>, DateCounterAsyncMongoRepository>();

            services.AddMvc();
        }
    }
}