using E_Com.Core.Interfaces;
using E_Com.Core.Services;
using E_Com.infrastructure.Data;
using E_Com.infrastructure.Repositories;
using E_Com.infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace E_Com.infrastructure
{
    public static class infrastructureRegisteration
    {
        public static IServiceCollection infrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //Apply Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IImageManageService, ImageManageService>();
            services.AddSingleton<IFileProvider>(
                             new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));


            //Apply Dbcontext
            services.AddDbContext<AppDbContext>(optipons =>
            {
                optipons.UseSqlServer(configuration.GetConnectionString("EcomDatabase"));
            });
            return services;
        }

    }
}
