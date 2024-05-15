using AutoMapper;
using FinalProject.MoveComponent.Models.Dto;
using FinalProject.MoveComponent.Repositories;
using FinalProject.Shared.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MoveComponent.Services.BusinessMove
{
    public class BusinessMoveService : IBusinessMoveService
    {
        private readonly IMapper _mapper;
        private readonly IMoveRepository _repository;

        public BusinessMoveService(IMapper mapper, IMoveRepository Repository)
        {
            _mapper = mapper;
            _repository = Repository;
        }
        public async Task<BusinessMoveDto> CreateBusinessMoveAsync(BusinessMoveDto businessMoveDto)
        {
            var businessMove = _mapper.Map<Move>(businessMoveDto);
            _ = await _repository.AddAsync(businessMove);

            return _mapper.Map<BusinessMoveDto>(businessMove);
        }

        public async Task<List<BusinessMoveDto>> GetBusinessMoves()
        {
            var businessMoves = await _repository.GetAllBusinessMovesAsync();
         
            var businessMoveDtos = businessMoves
                .Select(businessMove => _mapper.Map<BusinessMoveDto>(businessMove))
                .ToList();

            return businessMoveDtos;
        }

        public async Task<BusinessMoveDto> GetBusinessMoveByIdAsync(int id)
        {
            var businessMove = await _repository.GetByIdAsync(id);

            if (businessMove == null)
            {
                return null;
            }

            return _mapper.Map<BusinessMoveDto>(businessMove);
        }

    }
}
