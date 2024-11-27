using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Dtos;
using StockManagement.API.Mappers;
using StockManagement.Domain.Services;

namespace StockManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly StoreService _storeService;

        public StoresController(StoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet()]
        public IEnumerable<StoreDto> GetAll()
        {
            var stores = _storeService.GetAll();
            return StoreMapper.ToStoreDto(stores);
        }

        [HttpGet("{id}")]
        public StoreDto Get(int id)
        {
            var store = _storeService.GetStoreById(id);
            return StoreMapper.ToStoreDto(store);
        }

        [HttpPost("fetch")]
        public FetchDto<StoreDto> FetchStores([FromBody] FilterDto filterDto)
        {
            var fetchStoreModel = _storeService.FetchStores(filterDto.PageNumber, filterDto.PageSize, filterDto.Search, filterDto.SortBy, filterDto.SortDirection);
            return StoreMapper.ToStoreDto(fetchStoreModel);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public AddStoreDto Post([FromBody] StoreDto storeDto)
        {
            var username = HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var store = StoreMapper.ToStoreEntity(storeDto);
            store.CreatedBy = username;
            store = _storeService.AddStore(store);
            return StoreMapper.ToAddStoreDto(store);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public AddStoreDto Put(int id, [FromBody] StoreDto storeDto)
        {
            var username = HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var store = StoreMapper.ToStoreEntity(storeDto);
            store.ModifiedDate = DateTime.Now;
            store.ModifiedBy = username;

            store = _storeService.UpdateStore(id, store);
            return StoreMapper.ToAddStoreDto(store);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public StoreDto Delete(int id)
        {
            var store = _storeService.DeleteStore(id);
            return StoreMapper.ToStoreDto(store);
        }
    }
}
