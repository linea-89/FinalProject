using AutoMapper;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services.Room;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.Inventory
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

        public async Task<InventoryTypeDto> CreateInventoryType(InventoryTypeDto inventoryTypeDto)
        {
            var inventoryType = _mapper.Map<Models.InventoryType>(inventoryTypeDto);

            _context.InventoryTypes.Add(inventoryType);
            await _context.SaveChangesAsync();

            return _mapper.Map<InventoryTypeDto>(inventoryType);
        }

       /* public ActionResult<List<RoomTypeDto>> GetRoomTypes()
        {
            var roomTypes = _context.RoomTypes.ToList();

            // Map the result to the PrivateMoveDto list
            var result = roomTypes
                .Select(result => _mapper.Map<RoomTypeDto>(result))
                .ToList(); // Materialize the query into a list

            return result;
        }*/
    }
}
