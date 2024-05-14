using FinalProject.Data;
using FinalProject.Shared.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.FloorComponent.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly FinalProjectContext _context;
        public FloorRepository(FinalProjectContext context)
        {
            _context = context;
        }


        public async Task<Floor> AddAsync(Floor floor)
        {
            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();
            return floor;
        }

        public async Task<List<Floor>> GetFloors()
        {
            return await _context.Floors.ToListAsync();
        }






    }
}
