using Microsoft.EntityFrameworkCore;

using FinalProject.Data;
using FinalProject.Shared.Models.Domain;

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
