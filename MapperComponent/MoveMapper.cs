using AutoMapper;
using FinalProject.Models.MoveModels;
using FinalProject.MoveComponent.Dto;
using FinalProject.Shared.MapperInterfaces;
using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.MapperComponent
{
    public class MoveMapper : IMoveMapper
    {
        private readonly IMapper _mapper;

        public MoveMapper(IMapper mapper)
        {
            _mapper = mapper;
        }



        //Private move mappers
        public Move MapCreatedPrivateMove(PrivateMoveDto privateMoveDto)
        {
            return _mapper.Map<Move>(privateMoveDto);
        }

        public PrivateMoveDto MapPrivateMoveResponse(IMove move)
        {
            return _mapper.Map<PrivateMoveDto>(move);
        }

        public List<PrivateMoveDto> MapPrivateMovesRespons(List<IMove> moves)
        {
            return moves
                .Select(move => _mapper
                .Map<PrivateMoveDto>(move))
                .ToList();
        }

        //Business move mappers
        public Move MapCreatedBusinessMove(BusinessMoveDto businessMoveDto)
        {
            return _mapper.Map<Move>(businessMoveDto);
        }

        public BusinessMoveDto MapBusinessMoveResponse(IMove move)
        {
            return _mapper.Map<BusinessMoveDto>(move);
        }

        public List<BusinessMoveDto> MapBusinessMovesRespons(List<IMove> moves)
        {
            return moves
                .Select(move => _mapper
                .Map<BusinessMoveDto>(move))
                .ToList();
        }


    }
}
