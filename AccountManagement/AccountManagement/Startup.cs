using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AccountManagement.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using System.IO;
using AutoMapper;
using Newtonsoft.Json.Serialization;

namespace AccountManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //configuring logger service
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            //     .AddNewtonsoftJson(options =>
            //     {
            //         options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //     });
            services.ConfigureCors();
            services.AddCors();
            services.ConfigureLoggerService();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureRepositoryWrapper();
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();        ////keeping it above raises an error!!!


            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();



            //will forward proxy headers to the current request. This will help us during the Linux deployment.
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
