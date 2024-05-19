using FinalProject.MoveComponent.Dto;
using FinalProject.Shared.MapperInterfaces;
using FinalProject.Shared.RepositoryInterfaces;

namespace FinalProject.MoveComponent.Services.BusinessMove
{
    public class BusinessMoveService : IBusinessMoveService
    {
        private readonly IMoveRepository _repository;
        private readonly IMoveMapper _mapper;

        public BusinessMoveService(IMoveRepository Repository, IMoveMapper moveMapper)
        {
            _repository = Repository;
            _mapper = moveMapper;
        }
        public async Task<BusinessMoveDto> CreateBusinessMoveAsync(BusinessMoveDto businessMoveDto)
        {
            var businessMove = _mapper.MapCreatedBusinessMove(businessMoveDto);
            _ = await _repository.AddAsync(businessMove);

            return _mapper.MapBusinessMoveResponse(businessMove);
        }

        public async Task<List<BusinessMoveDto>> GetBusinessMoves()
        {
            var businessMoves = await _repository.GetAllBusinessMovesAsync();
           // var mappedMoves = _moveMapper.MapBusinessMovesRespons(businessMoves);
            //var businessMoveDtos = businessMoves
            //    .Select(businessMove => _mapper.Map<BusinessMoveDto>(businessMove))
            //    .ToList();

            return _mapper.MapBusinessMovesRespons(businessMoves);
        }

        public async Task<BusinessMoveDto> GetBusinessMoveById(int id)
        {
            var businessMove = await _repository.GetByIdAsync(id);

            if (businessMove == null)
            {
                return null;
            }

            return _mapper.MapBusinessMoveResponse(businessMove);
        }

    }
}
