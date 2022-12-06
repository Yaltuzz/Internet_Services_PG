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
using Microsoft.OpenApi.Models;
using Internet_Services_PG.Models;
using Internet_Services_PG.Services;
using Microsoft.Extensions.Options;

namespace Internet_Services_PG
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DatabaseSetting>(
                Configuration.GetSection(nameof(DatabaseSetting)));
            services.AddControllersWithViews();
            services.AddSingleton<IDatabaseSetting>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSetting>>().Value);
            services.AddSingleton<PressureService>();
            services.AddSingleton<HumidityService>();
            services.AddSingleton<RadiationService>();
            services.AddSingleton<TemperatureService>();
            services.AddHostedService<TemperatureConsumerService>();
            services.AddHostedService<RadiationConsumerService>();
            services.AddHostedService<HumidityConsumerService>();
            services.AddHostedService<PressureConsumerService>();
            services.AddControllers();
            services.AddRazorPages();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Internet_Services_PG", Version = "v1" });
            // });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Internet_Services_PG v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}