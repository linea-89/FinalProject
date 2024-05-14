using FinalProject.MoveComponent.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MoveComponent.Services.BusinessMove
{
    public interface IBusinessMoveService
    {
        public Task<BusinessMoveDto> CreateBusinessMoveAsync(BusinessMoveDto businessMoveDto);
        public ActionResult<List<BusinessMoveDto>> GetBusinessMoves();
        public Task<BusinessMoveDto> GetBusinessMoveByIdAsync(int id);
    }
}