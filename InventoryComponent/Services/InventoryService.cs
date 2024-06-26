﻿using FinalProject.InventoryComponent.Dto;
using FinalProject.Shared.MapperInterfaces;
using FinalProject.Shared.RepositoryInterfaces;



namespace FinalProject.InventoryComponent.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;
        private readonly IInventoryMapper _mapper;

        public InventoryService(IInventoryRepository repository, IInventoryMapper inventoryMapper)
        {
            _repository = repository;
            _mapper = inventoryMapper;
        }

        public async Task<InventoryDto> AddInventoryItem(InventoryDto inventoryDto)
        {
            var item = _mapper.MapAddedInventory(inventoryDto);
            _ = await _repository.AddInventoryItemAsync(item);

            return _mapper.MapInventoryResponse(item);
        }

        public async Task<List<InventoryDto>> GetInventoryItems(int roomId)
        {
            var items = await _repository.GetInventoryItemsAsync(roomId);

            if (items == null)
            {
                return null;
            }
            
            var result = _mapper.MapInventoryItemsResponse(items);

            return result;
        }

        public async Task<InventoryTypeDto> CreateInventoryType(InventoryTypeDto inventoryTypeDto)
        {
            var inventoryType = _mapper.MapCreatedInventoryType(inventoryTypeDto);

            _ = await _repository.CreateInventoryTypeAsync(inventoryType);

            return _mapper.MapInventoryTypeResponse(inventoryType);
        }

        public async Task<List<InventoryTypeDto>> GetInventoryTypes()
        {
            var inventoryTypes = await _repository.GetInventoryTypesAsync();
            var mappedResult = _mapper.MapInventoryTypeRespons(inventoryTypes);

            return mappedResult;
        }
    }
}
