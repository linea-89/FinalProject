using FinalProject.Models.MoveModels;
using FinalProject.MoveComponent.Dto;
using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Shared.MapperInterfaces
{
    public interface IMoveMapper
    {
        public Move MapCreatedPrivateMove(PrivateMoveDto privateMoveDto);
        public List<PrivateMoveDto> MapPrivateMovesRespons(List<IMove> moves);
        public PrivateMoveDto MapPrivateMoveResponse(IMove move);
    }
}