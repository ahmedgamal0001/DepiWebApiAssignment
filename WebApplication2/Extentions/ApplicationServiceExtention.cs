using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2.Extentions
{
    public static class ApplicationServiceExtention 
    {
        public static IServiceCollection AddServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultSqlConnection")));

            return services;
        }
    }
}
