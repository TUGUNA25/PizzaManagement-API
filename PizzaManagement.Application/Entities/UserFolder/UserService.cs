
using Mapster;
using PizzaManagement.Application.Exceptions;
using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Application.Entities.UserFolder
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repositoryUser;
        private readonly IAddressRepository _repositoryAddress;
        public UserService(IUserRepository repositoryUser, IAddressRepository repositoryAddress)
        {
            _repositoryUser = repositoryUser;
            _repositoryAddress = repositoryAddress;
        }

        public async Task Create(UserRequestModel user)
        {
            var adapted = user.Adapt<User>();

            if (await _repositoryUser.Exists(adapted.Id))
            {
                throw new UserAlreadyExistsException();
            }
            foreach (var address in adapted.Addresses)
            {
                if (!await _repositoryAddress.Exists(address.Id))
                   throw new AddressNotFoundException();
                if (user.Id != address.UserId)
                    throw new UserAlreadyExistsException();
            }
            await _repositoryUser.Create(adapted);
        }

        public async Task Delete(int id)
        {
            if (!await _repositoryUser.Exists(id))
            {
                throw new UserNotFoundException();
            }
            await _repositoryUser.Delete(id);
        }

        public async Task<UserResponseModel> Get(int id)
        {
            if (!await _repositoryUser.Exists(id))
            {
                throw new UserNotFoundException();
            }

            var result = await _repositoryUser.Get(id);
            return result.Adapt<UserResponseModel>();
        }

        public async Task<List<UserResponseModel>> GetMany(params int[] id)
        {
            foreach (int i in id)
            {
                if (!await _repositoryUser.Exists(i))
                {
                    throw new UserNotFoundException();
                }
            }
            var result = await _repositoryUser.GetMany(id);
            return result.Adapt<List<UserResponseModel>>();
        }

        public async Task Update(UserRequestModel user)
        {
            var adapted = user.Adapt<User>();
            if (!await _repositoryUser.Exists(adapted.Id))
            {
                throw new UserNotFoundException();
            }
            foreach (var address in adapted.Addresses)
            {
                if (!await _repositoryAddress.Exists(address.Id))
                    throw new AddressNotFoundException();
                if (user.Id != address.UserId)
                    throw new UserAlreadyExistsException();
            }
            await _repositoryUser.Update(adapted);
        }

        public async Task<List<UserResponseModel>> GetAll()
        {
            var result = await _repositoryUser.GetAll();
            return result.Adapt<List<UserResponseModel>>();
        }

        public async Task<int> Length()
        {
            return await _repositoryUser.Length();
        }
    }
}
