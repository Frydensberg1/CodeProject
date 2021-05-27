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
using DrunkenWizard_API.Interfaces;
using DrunkenWizard_API.Repos;
using DrunkenWizard_API.Services;
using DrunkenWizard_API.Hubs;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using DrunkenWizard_API.Options;

namespace DrunkenWizard_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR(HubOptions =>
            {
                HubOptions.KeepAliveInterval = TimeSpan.FromSeconds(5);
            });
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "DrunkenWizard", Version = "v1" });
            });
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<Repository, Repository>();

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //  app.UseCors("AllowCors");
            var swaggeroptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggeroptions);
            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggeroptions.JsonRoute;

            });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggeroptions.UIEndPoint, swaggeroptions.Description);
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<PlayerHub>("/PlayerHub");
                endpoints.MapHub<GameHub>("/GameHub");

            });
        }
    }
}
