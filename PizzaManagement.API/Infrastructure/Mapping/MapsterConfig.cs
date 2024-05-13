using Mapster;
using PizzaManagement.API.Model.DTO;
using PizzaManagement.API.Model.Requests;
using PizzaManagement.Application.Entities.AddressFolder;
using PizzaManagement.Application.Entities.OrderFolder;
using PizzaManagement.Application.Entities.PizzaFolder;
using PizzaManagement.Application.Entities.UserFolder;
using PizzaManagement.Domain.Entity;

namespace PizzaManagement.API.Infrastructure.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            //User
            TypeAdapterConfig<UserResponseModel, UserResponseDTO>
                .NewConfig()
                .Map(dest => dest.AddressIds, src => src.Addresses.Select(address => address.Id).ToList());

            //Order
            TypeAdapterConfig<OrderResponseModel, OrderResponseDTO>
                .NewConfig()
                .Map(dest => dest.PizzaIds, src => src.Pizzas.Select(pizza => pizza.Id).ToList())
                .Map(dest => dest.Ranks, src => src.RankHistory.Select(rank => rank.Rank).ToList());
        }
    }
}
