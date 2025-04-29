using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shop.BusinessLogic;
using shop.DataAccess;
using shop.IBusinessLogic;
using shop.IDataAccess;

namespace shop.ServiceFactory
{
    public class ServiceFactory
    {
        public void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserLogic, UserLogic>();
        }
    }
}