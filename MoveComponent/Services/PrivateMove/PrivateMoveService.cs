using FinalProject.MoveComponent.Dto;
using FinalProject.Shared.RepositoryInterfaces;
using FinalProject.Shared.MapperInterfaces;

namespace FinalProject.MoveComponent.Services.PrivateMove
{
    public class PrivateMoveService : IPrivateMoveService
    {
        private readonly IMoveRepository _repository;
        private readonly IMoveMapper _moveMapper;

        public PrivateMoveService(IMoveRepository repository, IMoveMapper moveMapper)
        {
            _repository = repository;
            _moveMapper = moveMapper;
        }

        public async Task<PrivateMoveDto> CreatePrivateMove(PrivateMoveDto privateMoveDto)
        {
            var privateMove = _moveMapper.MapCreatedPrivateMove(privateMoveDto);
            _ = await _repository.AddAsync(privateMove);

            return _moveMapper.MapPrivateMoveResponse(privateMove);
        }

        public async Task<List<PrivateMoveDto>> GetPrivateMoves()
        {
            var privateMoves = await _repository.GetAllPrivateMovesAsync();
            var mappedMoves = _moveMapper.MapPrivateMovesRespons(privateMoves);

            return mappedMoves;
        }

        public async Task<PrivateMoveDto> GetPrivateMoveById(int id)
        {
            var privateMove = await _repository.GetByIdAsync(id);

            if (privateMove == null)
            {
                return null;
            }

            return _moveMapper.MapPrivateMoveResponse(privateMove);
        }

    }
}
