using FinalProject.MoveComponent.Models.Dto;

namespace FinalProject.MoveComponent.Services.PrivateMove
{
    public interface IPrivateMoveService
    {
        public Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto);
        public Task<List<PrivateMoveDto>> GetPrivateMovesAsync();
        public Task<PrivateMoveDto> GetPrivateMoveByIdAsync(int id);

    }
}