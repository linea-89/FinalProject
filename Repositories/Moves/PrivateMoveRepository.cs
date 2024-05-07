using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using FinalProject.Data;

namespace FinalProject.Repositories.Moves
{

    //the repository pattern
    public class PrivateMoveRepository : IPrivateMoveRepository
    {
        private readonly FinalProjectContext _context;

        public PrivateMoveRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<List<PrivateMove>> GetAllPrivateMoves()
        {
            return await _context.PrivateMoves.ToListAsync();
        }
    }
}
