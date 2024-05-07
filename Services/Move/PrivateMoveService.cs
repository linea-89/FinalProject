using AutoMapper;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.Move
{
    public class PrivateMoveService : IPrivateMoveService
    {
        private readonly FinalProjectContext _context;
        private readonly IMapper _mapper;

        public PrivateMoveService(FinalProjectContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public string GetAllPrivateMoves(string text)
        {
            string toPrint = text;
            return toPrint;
        }

        //public Task<IActionResult> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto)
        //{
        //    var privateMove = _mapper.Map<PrivateMove>(privateMoveDto);

        //    // Add the mapped entity to the context and save
        //    _context.PrivateMoves.Add(privateMove);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(PostPrivateMoveNew), new { id = privateMoveDto.Name }, privateMoveDto);
        //}

        public async Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto)
        {
            var privateMove = _mapper.Map<PrivateMove>(privateMoveDto);

            // Add the mapped entity to the context and save
            _context.PrivateMoves.Add(privateMove);
            await _context.SaveChangesAsync();

            // Optionally, map the saved entity back to a DTO for return
            return _mapper.Map<PrivateMoveDto>(privateMove);
        }
    }
}
