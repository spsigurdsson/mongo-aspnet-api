using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace mongo_aspnet_api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            
                 Configuration = builder.Build();
            

        }

        public IConfigurationRoot Configuration { get; }

        private static readonly string MONGO_URL = "MONGO_URL";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var st  = Configuration[MONGO_URL];
            if (st == null)
            {
                throw new KeyNotFoundException($"Environment variable for {MONGO_URL} was not found.");
            }else{
                Console.WriteLine("");
                Console.WriteLine(MONGO_URL);
                Console.WriteLine("");
            }


            services.Configure<Settings>(Configuration);
            services.AddMvc();

            services.AddSingleton<IMongoAsyncRepository<DateCounter>, DateCounterAsyncMongoRepository>();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
