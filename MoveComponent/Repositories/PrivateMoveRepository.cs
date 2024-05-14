using Microsoft.EntityFrameworkCore;
using FinalProject.MoveComponent.Models.Domain;

using FinalProject.Data;

namespace FinalProject.MoveComponent.Repositories
{

    //the repository pattern
    public class PrivateMoveRepository : IPrivateMoveRepository
    {
        private readonly FinalProjectContext _context;

        public PrivateMoveRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<List<Move>> GetAllPrivateMoves()
        {
            return await _context.Moves.ToListAsync();
        }
    }
}
