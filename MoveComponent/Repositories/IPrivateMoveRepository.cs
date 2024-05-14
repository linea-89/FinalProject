using FinalProject.Shared.Models.Domain;

namespace FinalProject.MoveComponent.Repositories
{
    public interface IPrivateMoveRepository
    {
        Task<List<Move>> GetAllPrivateMoves();


    }
}