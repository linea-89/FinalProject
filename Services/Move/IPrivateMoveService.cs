using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.Move
{
    public interface IPrivateMoveService
    {
        public string GetAllPrivateMoves(string text);

        Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto);
    }
}