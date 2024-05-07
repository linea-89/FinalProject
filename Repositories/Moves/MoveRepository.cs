using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using FinalProject.Data;

namespace FinalProject.Repositories.Moves
{

    //the repository pattern
    public class MoveRepository : IMoveRepository
    {
        private readonly FinalProjectContext _context;

        public MoveRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<List<PrivateMove>> GetAllMoves()
        {
            return await _context.PrivateMoves.ToListAsync();
        }
    }
}
