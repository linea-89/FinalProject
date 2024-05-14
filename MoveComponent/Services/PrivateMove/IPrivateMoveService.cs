using FinalProject.MoveComponent.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MoveComponent.Services.PrivateMove
{
    public interface IPrivateMoveService
    {
        public Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto);
        public ActionResult<List<PrivateMoveDto>> GetPrivateMoves();
        public Task<PrivateMoveDto> GetPrivateMoveByIdAsync(int id);

    }
}