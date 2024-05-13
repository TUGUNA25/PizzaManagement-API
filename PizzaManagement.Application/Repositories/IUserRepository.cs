using PizzaManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagement.Application.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetMany(params int[] id);
        public Task<User> Get(int id);
        public Task Create(User user);
        public Task Update(User user);
        public Task Delete(int id);
        public Task<bool> Exists(int id);
        public Task<int> Length();
        public Task<List<User>> GetAll();
    }
}
