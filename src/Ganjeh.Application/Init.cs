using AutoMapper;
using Ganjeh.Application.Services;
using Ganjeh.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ganjeh.Application
{
    public static class Init
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(Init));
            services.AddScoped<IRegionServices, RegionServices>();
        }
    }
}