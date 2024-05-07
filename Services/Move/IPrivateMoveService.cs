using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.Move
{
    public interface IPrivateMoveService
    {
        public ActionResult<List<PrivateMoveDto>> GetAllPrivateMoves();

        public Task<PrivateMoveDto> GetPrivateMoveByIdAsync(int id);

        public Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto);

    }
}