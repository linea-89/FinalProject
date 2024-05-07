using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.Move
{
    public interface IPrivateMoveService
    {
        public ActionResult<List<PrivateMoveDto>> GetAllPrivateMoves();

        Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto);

    }
}