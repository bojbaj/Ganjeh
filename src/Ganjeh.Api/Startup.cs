using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganjeh.Api.Middlewares;
using Ganjeh.Application.Interfaces;
using Ganjeh.Application.Services;
using Ganjeh.Domain.Base;
using Ganjeh.Domain.Interfaces;
using Ganjeh.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Ganjeh.Api
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            // options.BackchannelHttpHandler = new HttpClientHandler
                            // {
                            //     Proxy = Helpers.Lib.HttpClientManager.GetWebProxy(proxySettings)
                            // };
                            // options.Authority = $"https://securetoken.google.com/{fireBaseProjectId}";
                            // options.TokenValidationParameters = new TokenValidationParameters
                            // {
                            //     ValidateIssuer = true,
                            //     ValidIssuer = $"https://securetoken.google.com/{fireBaseProjectId}",
                            //     ValidateAudience = true,
                            //     ValidAudience = fireBaseProjectId,
                            //     ValidateLifetime = true
                            // };
                        });
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppDbContext"));
            });
            
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped<IRegionServices, RegionServices>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ganjeh.Api", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("ApiCorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        //.AllowCredentials()
                        );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ganjeh.Api v1"));
            }

            app.ConfigureExceptionHandler(logger);

            app.UseRouting();

            app.UseCors("ApiCorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
