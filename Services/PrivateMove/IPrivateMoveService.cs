using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.Move
{
    public interface IPrivateMoveService
    {
        public Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto);
        public ActionResult<List<PrivateMoveDto>> GetPrivateMoves();
        public Task<PrivateMoveDto> GetPrivateMoveByIdAsync(int id);

    }
}