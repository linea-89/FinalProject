using FinalProject.MoveComponent.Models.Domain;

namespace FinalProject.MoveComponent.Repositories
{
    public interface IPrivateMoveRepository
    {
        Task<List<Move>> GetAllPrivateMoves();


    }
}