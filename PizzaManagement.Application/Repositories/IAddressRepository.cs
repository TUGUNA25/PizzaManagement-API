using PizzaManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Repositories
{
    public interface IAddressRepository
    {
        public Task<List<Address>> GetMany(params int[] id);
        public Task<List<Address>> GetAll();
        public Task<Address> Get(int id);
        public Task Create(Address address);
        public Task Update(Address address);
        public Task Delete(int id);
        public Task<bool> Exists(int id);
        public Task<int> Length();
    }
}
