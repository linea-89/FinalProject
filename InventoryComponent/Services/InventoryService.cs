using AutoMapper;
using FinalProject.InventoryComponent.Models.Domain;
using FinalProject.InventoryComponent.Models.Dto;
using FinalProject.InventoryComponent.Repositories;
using FinalProject.Shared.Models.Domain;


namespace FinalProject.InventoryComponent.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMapper _mapper;
        private readonly IInventoryRepository _repository;

        public InventoryService(IMapper mapper, IInventoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<InventoryDto> AddInventoryItem(InventoryDto inventoryDto)
        {
            var item = _mapper.Map<Inventory>(inventoryDto);
            var result = await _repository.AddInventoryItemAsync(item);

            return _mapper.Map<InventoryDto>(item);
        }

        public async Task<List<InventoryDto>> GetInventoryItem(int roomId)
        {
            var items = await _repository.GetInventoryItemAsync(roomId);
            var result = _mapper.Map<List<InventoryDto>>(items);

            return result;
        }

        public async Task<InventoryTypeDto> CreateInventoryType(InventoryTypeDto inventoryTypeDto)
        {
            var inventoryType = _mapper.Map<InventoryType>(inventoryTypeDto);

            var addedInventoryType = await _repository.CreateInventoryTypeAsync(inventoryType);

            return _mapper.Map<InventoryTypeDto>(inventoryType);
        }

        public async Task<List<InventoryTypeDto>> GetInventoryTypes()
        {
            var inventoryTypes = await _repository.GetInventoryTypesAsync();

            var result = inventoryTypes
                .Select(result => _mapper.Map<InventoryTypeDto>(result))
                .ToList();

            return result;
        }
    }
}
