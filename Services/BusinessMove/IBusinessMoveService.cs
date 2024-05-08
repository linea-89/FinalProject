using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.BusinessMove
{
    public interface IBusinessMoveService
    {
        public ActionResult<List<BusinessMoveDto>> GetBusinessMoves();

        public Task<BusinessMoveDto> GetBusinessMoveByIdAsync(int id);

        public Task<BusinessMoveDto> CreateBusinessMoveAsync(BusinessMoveDto businessMoveDto);
    }
}