using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;

namespace UserManagement.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        
        List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Nanuka", LastName = "Xurcidze", Email = "nanuka@gmail.com", PhoneNumber = "551115003", Addresses = new List<Address> { new Address { Id = 1, UserId = 1, City = "Paris", Country = "France", Region = "Île-de-France", Description = "Residential Address" }, new Address { Id = 2, UserId = 1, City = "Berlin", Country = "Germany", Region = "Berlin", Description = "Office Address" } } },
            new User { Id = 2, FirstName = "Tekla", LastName = "Fanjaradze", Email = "tekla@gmail.ge", PhoneNumber = "595343449", Addresses = new List<Address> { new Address { Id = 3, UserId = 2, City = "New York City", Country = "United States", Region = "New York", Description = "Central Park Address" } } },
        };
       

        public async Task Create(User user)
        {
            _users.Add(user);
        }

        public async Task Delete(int id)
        {
            var user = await Get(id);
            _users.Remove(user);
        }

        public async Task<bool> Exists(int id)
        {
            return await Task.FromResult(_users.Any(user => user.Id == id));
        }

        public async Task<User> Get(int id)
        {
            return await Task.FromResult(_users.Single(users => users.Id == id));
        }

        public async Task<List<User>> GetMany(params int[] id)
        {
            List<User> users = new List<User>();
            foreach (int i in id)
            {
                users.Add(await Get(i));
            }
            return users;
        }

        public async Task Update(User User)
        {
            _users[User.Id - 1] = User;

        }

        public async Task<int> Length()
        {
            return _users.Count;
        }

        public async Task<List<User>> GetAll()
        {
            return _users;
        }
    }
}
