using StockManagement.API.Dtos;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Models;

namespace StockManagement.API.Mappers
{
    public class StoreMapper
    {
        public static IEnumerable<StoreDto> ToStoreDto(IEnumerable<Store> model)
        {
            return model.Select(s => new StoreDto()
            {
                Id = s.Id,
                Name = s.Name,
                StoreKeeperId = s.StoreKeeperId,
                StoreKeeperName = s.StoreKeeper.Username
            });
        }

        public static StoreDto ToStoreDto(Store model)
        {
            return new StoreDto()
            {
                Id = model.Id,
                Name = model.Name,
                StoreKeeperId = model.StoreKeeperId,
                StoreKeeperName = model.StoreKeeper.Username
            };
        }

        public static AddStoreDto ToAddStoreDto(Store model)
        {
            return new AddStoreDto()
            {
                Id = model.Id,
                Name = model.Name,
                StoreKeeperId = model.StoreKeeperId
            };
        }

        public static FetchDto<StoreDto> ToStoreDto(FetchModel<Store> model)
        {
            FetchDto<StoreDto> dto = new FetchDto<StoreDto>();

            dto.TotalEntities = model.TotalEntities;

            dto.Entities = model.Entities.Select(s => new StoreDto()
            {
                Id = s.Id,
                Name = s.Name,
                StoreKeeperId = s.StoreKeeperId,
                StoreKeeperName= s.StoreKeeper.Username
            });

            return dto;
        }

        public static Store ToStoreEntity(StoreDto dto)
        {
            return new Store()
            {
                Name = dto.Name,
                StoreKeeperId = dto.StoreKeeperId,
                
            };
        }
    }
}
