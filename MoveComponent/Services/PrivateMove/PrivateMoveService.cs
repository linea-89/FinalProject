using AutoMapper;
using FinalProject.MoveComponent.Models.Dto;
using FinalProject.Shared.Models.Domain;
using FinalProject.Repositories.Interfaces;

namespace FinalProject.MoveComponent.Services.PrivateMove
{
    public class PrivateMoveService : IPrivateMoveService
    {
        private readonly IMapper _mapper;
        private readonly IMoveRepository _repository;

        public PrivateMoveService(IMapper mapper, IMoveRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PrivateMoveDto> CreatePrivateMoveAsync(PrivateMoveDto privateMoveDto)
        {
            var privateMove = _mapper.Map<Move>(privateMoveDto);
            _ = await _repository.AddAsync(privateMove);

            return _mapper.Map<PrivateMoveDto>(privateMove);
        }

        public async Task<List<PrivateMoveDto>> GetPrivateMovesAsync()
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
