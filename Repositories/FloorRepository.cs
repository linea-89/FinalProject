using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using FinalProject.Shared.ModelInterfaces;
using FinalProject.Shared.RepositoryInterfaces;
using FinalProject.Models.FloorModels;


namespace FinalProject.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly FinalProjectContext _context;
        public FloorRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<IFloor> AddFloorAsync(IFloor floor)
        {
            var floorEntity = floor as Floor;
            _ = _context.Floors.Add(floorEntity);
            await _context.SaveChangesAsync();

            return floorEntity;
        }

        public async Task<List<IFloor>> GetFloorsAsync(int moveId)
        {
            return await _context.Floors
                .Where(x => x.MoveId == moveId)
                .ToListAsync<IFloor>();
        }
        public async Task<IFloor> GetFloorByIdAsync(int moveId, int id)
        {
            var floor = await _context.Floors
                .Where(x => x.MoveId == moveId && x.Id == id)
                .FirstOrDefaultAsync();

            return floor;
        }

        public async Task<IFloorType> CreateFloorTypeAsync(IFloorType floorType)
        {
            var floorTypeEntity = floorType as FloorType;
            _context.FloorTypes.Add(floorTypeEntity);
            await _context.SaveChangesAsync();

            return floorTypeEntity;
        }

        public async Task<List<IFloorType>> GetFloorTypesAsync()
        {
            return await _context.FloorTypes.ToListAsync<IFloorType>();
        }
    }
}
