using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.MoveComponent.Models.Domain;

namespace FinalProject.MoveComponent.Repositories
{

    //the repository pattern
    public class MoveRepository : IMoveRepository
    {
        private readonly FinalProjectContext _context;

        public MoveRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<List<Move>> GetAllMoves()
        {
            return await _context.Moves.ToListAsync();
        }
    }
}
