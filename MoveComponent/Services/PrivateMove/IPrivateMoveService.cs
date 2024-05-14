using FinalProject.MoveComponent.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MoveComponent.Services.PrivateMove
{
    public interface IPrivateMoveService
    {
        public Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto);
        public Task<ActionResult<List<PrivateMoveDto>>> GetPrivateMovesAsync();
        public Task<PrivateMoveDto> GetPrivateMoveByIdAsync(int id);

    }
}