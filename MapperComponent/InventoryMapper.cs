using AutoMapper;
using FinalProject.InventoryComponent.Dto;
using FinalProject.Models.InventoryModels;
using FinalProject.Shared.MapperInterfaces;
using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.MapperComponent
{
    public class InventoryMapper : IInventoryMapper
    {
        private readonly IMapper _mapper;

        public InventoryMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Inventory MapAddedInventory(InventoryDto inventoryDto)
        {
            return _mapper.Map<Inventory>(inventoryDto);

        }

        public InventoryDto MapInventoryResponse(IInventory inventory)
        {
            return _mapper.Map<InventoryDto>(inventory);
        }
        public List<InventoryDto> MapInventoryItemsResponse(List<IInventory> inventoryItems)
        {
            return inventoryItems
                .Select(inventoryItem => _mapper
                .Map<InventoryDto>(inventoryItem))
                .ToList();
        }

        public InventoryType MapCreatedInventoryType(InventoryTypeDto inventoryTypeDto)
        {
            return _mapper.Map<InventoryType>(inventoryTypeDto);
        }

        public InventoryTypeDto MapInventoryTypeResponse(IInventoryType inventoryType)
        {
            return _mapper.Map<InventoryTypeDto>(inventoryType);
        }

        public List<InventoryTypeDto> MapInventoryTypeRespons(List<IInventoryType> inventoryTypes)
        {
            return inventoryTypes
                .Select(inventoryType => _mapper
                .Map<InventoryTypeDto>(inventoryType))
                .ToList();
        }
    }
}
