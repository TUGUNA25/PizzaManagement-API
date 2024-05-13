using PizzaManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetMany(params int[] id);
        public Task<Order> Get(int id);
        public Task Create(Order order);
        public Task<bool> Exists(int id);
        public Task<int> Length();
        public Task<List<Order>> GetAll();
    }
}
