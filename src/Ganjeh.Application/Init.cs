using AutoMapper;
using Ganjeh.Application.Services;
using Ganjeh.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ganjeh.Application
{
    public static class Init
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(Init));
            services.AddScoped<IRegionCountryService, RegionCountryService>();
            services.AddScoped<IRegionStateService, RegionStateService>();
            services.AddScoped<IRegionCityService, RegionCityService>();
            services.AddScoped<IPostCategoryService, PostCategoryService>();
            services.AddScoped<IPostService, PostService>();
        }
    }
}