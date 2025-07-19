using E_Com.Core.Interfaces;
using E_Com.infrastructure.Data;
using E_Com.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Com.infrastructure
{
    public static class infrastructureRegisteration
    {
        public static IServiceCollection infrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //Apply Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Apply Dbcontext
            services.AddDbContext<AppDbContext>(optipons =>
            {
                optipons.UseSqlServer(configuration.GetConnectionString("EcomDatabase"));
            });
            return services;
        }

    }
}
