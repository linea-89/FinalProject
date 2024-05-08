using FinalProject.Models;

namespace FinalProject.Repositories.Moves
{
    public interface IPrivateMoveRepository
    {
        Task<List<Move>> GetAllPrivateMoves();

           
    }
}