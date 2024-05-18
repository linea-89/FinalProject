using FinalProject.MoveComponent.Dto;

namespace FinalProject.MoveComponent.Services.BusinessMove
{
    public interface IBusinessMoveService
    {
        public Task<BusinessMoveDto> CreateBusinessMoveAsync(BusinessMoveDto businessMoveDto);
        public Task<List<BusinessMoveDto>> GetBusinessMoves();
        public Task<BusinessMoveDto> GetBusinessMoveByIdAsync(int id);
    }
}