using AutoMapper;
using FinalProject.Data;
using FinalProject.MoveComponent.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Shared.Models.Domain;
using FinalProject.MoveComponent.Repositories;

namespace FinalProject.MoveComponent.Services.PrivateMove
{
    public class PrivateMoveService : IPrivateMoveService
    {
        private readonly ILogger<PrivateMoveService> _logger;
        private readonly IMapper _mapper;
        private readonly IMoveRepository _repository;

        public PrivateMoveService(ILogger<PrivateMoveService> logger, IMapper mapper, IMoveRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto)
        {
            var privateMove = _mapper.Map<Move>(privateMoveDto);

            var addedMove = await _repository.AddAsync(privateMove);

            return _mapper.Map<PrivateMoveDto>(addedMove);
        }

        public async Task<ActionResult<List<PrivateMoveDto>>> GetPrivateMovesAsync()
        {
            var privateMoves = await _repository.GetAllPrivateMovesAsync();

            var privateMoveDtos = privateMoves
                .Select(privateMove => _mapper.Map<PrivateMoveDto>(privateMove))
                .ToList();

            return privateMoveDtos;
        }

        public async Task<PrivateMoveDto> GetPrivateMoveByIdAsync(int id)
        {
            var privateMove = await _repository.GetByIdAsync(id);

            if (privateMove == null)
            {
                return null;
            }

            return _mapper.Map<PrivateMoveDto>(privateMove);
        }

    }
}
