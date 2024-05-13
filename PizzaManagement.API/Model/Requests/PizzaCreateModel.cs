

namespace PizzaManagement.API.Model.Requests
{
    public class PizzaCreateModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CaloryCount { get; set; }
    }
}
