using AutoMapper;
using FinalProject.Data;
using FinalProject.InventoryComponent.Models.Domain;
using FinalProject.InventoryComponent.Models.Dto;
using FinalProject.Shared.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.InventoryComponent.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly ILogger<InventoryService> _logger;
        private readonly IMapper _mapper;
        private readonly FinalProjectContext _context;

        public InventoryService(ILogger<InventoryService> logger, IMapper mapper, FinalProjectContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<InventoryDto> AddInventoryItem(InventoryDto inventoryDto)
        {
            var item = _mapper.Map<Inventory>(inventoryDto);

            _context.Inventory.Add(item);
            await _context.SaveChangesAsync();

            return _mapper.Map<InventoryDto>(item);
        }

        public ActionResult<List<InventoryDto>> GetInventoryItem(int roomId)
        {
            var items = _context.Inventory
                .Where(x => x.RoomId == roomId)
                .ToList();

            // Map the result to the PrivateMoveDto list
            var result = _mapper.Map<List<InventoryDto>>(items);


            return result;
        }

        public async Task<InventoryTypeDto> CreateInventoryType(InventoryTypeDto inventoryTypeDto)
        {
            var inventoryType = _mapper.Map<InventoryType>(inventoryTypeDto);

            _context.InventoryTypes.Add(inventoryType);
            await _context.SaveChangesAsync();

            return _mapper.Map<InventoryTypeDto>(inventoryType);
        }

        public ActionResult<List<InventoryTypeDto>> GetInventoryTypes()
        {
            var inventoryTypes = _context.InventoryTypes.ToList();

            // Map the result to the PrivateMoveDto list
            var result = inventoryTypes
                .Select(result => _mapper.Map<InventoryTypeDto>(result))
                .ToList(); // Materialize the query into a list

            return result;
        }
    }
}
