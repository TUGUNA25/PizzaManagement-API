
using Mapster;
using PizzaManagement.Application.Entities.PizzaFolder;
using PizzaManagement.Application.Exceptions;
using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Application.Entities.AddressFolder
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repositoryAddress;
        private readonly IUserRepository _userRepository;


        public AddressService(IAddressRepository repositoryAddress, IUserRepository userRepository)
        {
            _repositoryAddress = repositoryAddress;
            _userRepository = userRepository;
        }

        public async Task Create(AddressRequestModel address)
        {
            var adapted = address.Adapt<Address>();

            if (await _repositoryAddress.Exists(adapted.Id))
            {
                throw new AddressAlreadyExistsException();
            }
            if (!await _userRepository.Exists(adapted.UserId))
            {
                throw new UserNotFoundException();
            }
            await _repositoryAddress.Create(adapted);
        }

        public async Task Delete(int id)
        {
            if (!await _repositoryAddress.Exists(id))
            {
                throw new AddressNotFoundException();
            }
            await _repositoryAddress.Delete(id);
        }

        public async Task<AddressResponseModel> Get(int id)
        {
            if (!await _repositoryAddress.Exists(id))
            {
                throw new AddressNotFoundException();
            }

            var result = await _repositoryAddress.Get(id);
            return result.Adapt<AddressResponseModel>();
        }

        public async Task<List<AddressResponseModel>> GetMany(params int[] id)
        {
            foreach (int i in id)
            {
                if (!await _repositoryAddress.Exists(i))
                {
                    throw new AddressNotFoundException();
                }
            }
            var result = await _repositoryAddress.GetMany(id);
            return result.Adapt<List<AddressResponseModel>>();
        }
            
        public async Task Update(AddressRequestModel address)
        {
            var adapted = address.Adapt<Address>();
            if (!await _repositoryAddress.Exists(adapted.Id))
            {
                throw new AddressNotFoundException();
            }
            await _repositoryAddress.Update(adapted);
        }

        public async Task<List<AddressResponseModel>> GetAll()
        {
            var result = await _repositoryAddress.GetAll();
            return result.Adapt<List<AddressResponseModel>>();
        }

        public async Task<int> Length()
        {
            return await _repositoryAddress.Length();
        }
    }
}
