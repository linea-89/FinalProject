using FinalProject.MoveComponent.Dto;

namespace FinalProject.MoveComponent.Services.PrivateMove
{
    public interface IPrivateMoveService
    {
        public Task<PrivateMoveDto> CreatePrivateMove(PrivateMoveDto privateMoveDto);
        public Task<List<PrivateMoveDto>> GetPrivateMoves();
        public Task<PrivateMoveDto> GetPrivateMoveById(int id);

    }
}