

using FinalProject.MoveComponent.Models.Domain;

namespace FinalProject.MoveComponent.Repositories
{
    public interface IMoveRepository
    {
        Task<List<Move>> GetAllMoves();


    }
}