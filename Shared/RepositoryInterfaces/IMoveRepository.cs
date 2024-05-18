using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Shared.RepositoryInterfaces
{
    public interface IMoveRepository
    {
        public Task<IMove> AddAsync(IMove move);
        public Task<List<IMove>> GetAllPrivateMovesAsync();
        public Task<List<IMove>> GetAllBusinessMovesAsync();
        public Task<IMove> GetByIdAsync(int id);

    }
}