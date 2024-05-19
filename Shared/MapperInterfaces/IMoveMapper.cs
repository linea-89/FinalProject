using FinalProject.Models.MoveModels;
using FinalProject.MoveComponent.Dto;
using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Shared.MapperInterfaces
{
    public interface IMoveMapper
    {
        //Private move mappers
        public Move MapCreatedPrivateMove(PrivateMoveDto privateMoveDto);
        public List<PrivateMoveDto> MapPrivateMovesRespons(List<IMove> moves);
        public PrivateMoveDto MapPrivateMoveResponse(IMove move);

        //Business move mappers
        public Move MapCreatedBusinessMove(BusinessMoveDto businessMoveDto);
        public BusinessMoveDto MapBusinessMoveResponse(IMove move);
        public List<BusinessMoveDto> MapBusinessMovesRespons(List<IMove> moves);

    }
}