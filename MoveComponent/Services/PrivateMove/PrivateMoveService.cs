using FinalProject.MoveComponent.Dto;
using FinalProject.Shared.RepositoryInterfaces;
using FinalProject.Shared.MapperInterfaces;

namespace FinalProject.MoveComponent.Services.PrivateMove
{
    public class PrivateMoveService : IPrivateMoveService
    {
        private readonly IMoveRepository _repository;
        private readonly IMoveMapper _mapper;

        public PrivateMoveService(IMoveRepository repository, IMoveMapper moveMapper)
        {
            _repository = repository;
            _mapper = moveMapper;
        }

        public async Task<PrivateMoveDto> CreatePrivateMove(PrivateMoveDto privateMoveDto)
        {
            var privateMove = _mapper.MapCreatedPrivateMove(privateMoveDto);
            _ = await _repository.AddAsync(privateMove);

            return _mapper.MapPrivateMoveResponse(privateMove);
        }

        public async Task<List<PrivateMoveDto>> GetPrivateMoves()
        {
            var privateMoves = await _repository.GetAllPrivateMovesAsync();
           // var mappedMoves = _moveMapper.MapPrivateMovesRespons(privateMoves);

            return _mapper.MapPrivateMovesRespons(privateMoves);
        }

        public async Task<PrivateMoveDto> GetPrivateMoveById(int id)
        {
            var privateMove = await _repository.GetByIdAsync(id);

            if (privateMove == null)
            {
                return null;
            }

            return _mapper.MapPrivateMoveResponse(privateMove);
        }

    }
}
