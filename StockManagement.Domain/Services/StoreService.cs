using StockManagement.Domain.Entities;
using StockManagement.Domain.Exceptions;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;

namespace StockManagement.Domain.Services
{
    public class StoreService
    {
        private IStoreRepository _storeRepository;
        private IUserRepository _userRepository;

        public StoreService(IStoreRepository storeRepository, IUserRepository userRepository)
        {
            _storeRepository = storeRepository;
            _userRepository = userRepository;
        }

        public Store GetStoreById(int id)
        {
            if (id == 0)
                throw new BadRequestException("Id should be greater than 0");

            Store store = _storeRepository.GetByIdAsync(id).Result;

            if (store == null)
                throw new NotFoundException($"Store with id {id} was not found");

            return store;
        }

        public IEnumerable<Store> GetAll()
        {
            IEnumerable<Store> stores = _storeRepository.GetAll().Result;

            if (stores == null)
                throw new NotFoundException("No store were found");

            return stores;
        }

        public FetchModel<Store> FetchStores(int pageNumber = 1, int pageSize = 10, string searchFilter = "", string sortBy = "id", string sortDirection = "asc")
        {
            FetchModel<Store> storesModel = _storeRepository.FetchAsync(pageNumber, pageSize, searchFilter, sortBy, sortDirection).Result;

            if (storesModel == null)
                throw new Exception("Could not fetch stores");

            return storesModel;
        }

        public Store AddStore(Store store)
        {
            if (string.IsNullOrEmpty(store.Name))
                throw new BadRequestException("Store name is required");

            if (store.StoreKeeperId <= 0)
                throw new BadRequestException("Store keeper is required");

            bool isUserExists = _userRepository.IsUserExistsAsync(store.StoreKeeperId).Result;

            if (isUserExists == false)
                throw new BadRequestException("Store keeper doesn't exists");

            store = _storeRepository.AddAsync(store).Result;

            if (store == null || store.Id <= 0)
                throw new Exception("Store was not added");

            return store;
        }

        public Store UpdateStore(int id, Store store)
        {
            if (id <= 0)
                throw new BadRequestException("Id should be greater than 0");

            var oldStore = _storeRepository.GetByIdAsync(id).Result;

            if (oldStore == null)
                throw new NotFoundException($"Store with id {id} was not found");

            store.CreatedBy = oldStore.CreatedBy;
            store.CreatedDate = oldStore.CreatedDate;


            if (string.IsNullOrEmpty(store.Name))
                throw new BadRequestException("Store name is required");

            if (store.StoreKeeperId <= 0)
                throw new BadRequestException("Store keeper is required");

            bool isUserExists = _userRepository.IsUserExistsAsync(store.StoreKeeperId).Result;

            if (isUserExists == false)
                throw new BadRequestException("Store keeper doesn't exists");

            store.Id = id;
            store = _storeRepository.Update(store);

            return store;
        }

        public Store DeleteStore(int id)
        {
            if (id == 0)
                throw new BadRequestException("Id should be greater than 0");

            Store store = _storeRepository.GetByIdAsync(id).Result;

            if (store == null)
                throw new NotFoundException($"Store with id {id} was not found");

            _storeRepository.Delete(store);
            return store;
        }
    }
}
