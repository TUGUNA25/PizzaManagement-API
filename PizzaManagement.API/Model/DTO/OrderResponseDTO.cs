using PizzaManagement.Domain.Entity;

namespace PizzaManagement.API.Model.DTO
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public List<int> PizzaIds { get; set; }
        public List<int> Ranks { get; set; }
    }
}
