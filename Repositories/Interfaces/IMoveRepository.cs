using FinalProject.Shared.Models.Domain;

namespace FinalProject.Repositories.Interfaces
{
    public interface IMoveRepository
    {
        public Task<Move> AddAsync(Move move);
        public Task<List<Move>> GetAllPrivateMovesAsync();
        public Task<List<Move>> GetAllBusinessMovesAsync();
        public Task<Move> GetByIdAsync(int id);

    }
}