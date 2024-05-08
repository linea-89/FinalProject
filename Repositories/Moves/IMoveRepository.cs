using FinalProject.Models;

namespace FinalProject.Repositories.Moves
{
    public interface IMoveRepository
    {
        Task<List<Move>> GetAllMoves();

           
    }
}