using FinalProject.Data;
using FinalProject.FloorComponent.Models.Domain;
using FinalProject.Repositories.Interfaces;
using FinalProject.Shared.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly FinalProjectContext _context;
        public FloorRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<Floor> AddFloorAsync(Floor floor)
        {
            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();

            return floor;
        }

        public async Task<List<Floor>> GetFloorsAsync()
        {
            return await _context.Floors.ToListAsync();
        }

        public async Task<FloorType> CreateFloorTypeAsync(FloorType floorType)
        {
            _context.FloorTypes.Add(floorType);
            await _context.SaveChangesAsync();

            return floorType;
        }

        public async Task<List<FloorType>> GetFloorTypesAsync()
        {
            return await _context.FloorTypes.ToListAsync();
        }

    }
}
