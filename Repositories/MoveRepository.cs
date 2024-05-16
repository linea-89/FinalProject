using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Shared.Models.Domain;
using FinalProject.Repositories.Interfaces;

namespace FinalProject.Repositories
{

    //the repository pattern
    public class MoveRepository : IMoveRepository
    {
        private readonly FinalProjectContext _context;

        public MoveRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<Move> AddAsync(Move move)
        {
            _context.Moves.Add(move);
            await _context.SaveChangesAsync();
            return move;
        }

        public async Task<List<Move>> GetAllPrivateMovesAsync()
        {
            return await _context.Moves
                .Include(x => x.Addresses)
                .Include(x => x.Amenities)
                .Where(x => x.Type == "private")
                .ToListAsync();
        }

        public async Task<List<Move>> GetAllBusinessMovesAsync()
        {
            return await _context.Moves
                .Include(x => x.Addresses)
                .Include(x => x.Amenities)
                .Where(x => x.Type == "business")
                .ToListAsync();
        }

        public async Task<Move> GetByIdAsync(int id)
        {
            return await _context.Moves
                .Include(x => x.Addresses)
                .Include(x => x.Amenities)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
