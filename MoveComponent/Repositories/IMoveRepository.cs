using FinalProject.Shared.Models.Domain;

namespace FinalProject.MoveComponent.Repositories
{
    public interface IMoveRepository
    {
        Task<List<Move>> GetAllMoves();


    }
}