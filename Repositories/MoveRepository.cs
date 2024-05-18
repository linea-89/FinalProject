using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models.MoveModels;
using FinalProject.Shared.ModelInterfaces;
using FinalProject.Shared.RepositoryInterfaces;

namespace FinalProject.Repositories
{

    public class MoveRepository : IMoveRepository
    {
        private readonly FinalProjectContext _context;

        public MoveRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<IMove> AddAsync(IMove move)
        {
            var moveEntity = move as Move;
            _ = _context.Moves.Add(moveEntity);
            await _context.SaveChangesAsync();
            return moveEntity;
        }

        public async Task<List<IMove>> GetAllPrivateMovesAsync()
        {
            return await _context.Moves
                .Include(x => x.Addresses)
                .Include(x => x.Amenities)
                .Where(x => x.Type == "private")
                .ToListAsync<IMove>();
        }

        public async Task<List<IMove>> GetAllBusinessMovesAsync()
        {
            return await _context.Moves
                .Include(x => x.Addresses)
                .Include(x => x.Amenities)
                .Where(x => x.Type == "business")
                .ToListAsync<IMove>();
        }

        public async Task<IMove> GetByIdAsync(int id)
        {
            return await _context.Moves
                .Include(x => x.Addresses)
                .Include(x => x.Amenities)
                .FirstOrDefaultAsync<IMove>(x => x.Id == id);
        }
    }
}
