using PizzaManagement.Application.Entities.AddressFolder;
using PizzaManagement.Application.Entities.OrderFolder;
using PizzaManagement.Application.Entities.PizzaFolder;
using PizzaManagement.Application.Entities.RankHistoryFolder;
using PizzaManagement.Application.Entities.UserFolder;
using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;
using PizzaManagement.Infrastructure.Repository;
using UserManagement.Infrastructure.Repository;

namespace PizzaManagement.API.Infrastructure.Extensions
{
    public static class PizzaServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IPizzaService, PizzaService>();
            services.AddSingleton<IPizzaRepository, PizzaRepository>();

            services.AddSingleton<IAddressService, AddressService>();
            services.AddSingleton<IAddressRepository, AddressRepository>();

            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IOrderRepository, OrderRepository>();

            services.AddSingleton<IRankHistoryService, RankHistoryService>();
            services.AddSingleton<IRankHistoryRepository, RankHistoryRepository>();

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
