﻿using AutoMapper;
using FinalProject.Data;
using FinalProject.MoveComponent.Models.Dto;
using FinalProject.MoveComponent.Repositories;
using FinalProject.Shared.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.MoveComponent.Services.BusinessMove
{
    public class BusinessMoveService : IBusinessMoveService
    {
        private readonly FinalProjectContext _context;
        private readonly IMapper _mapper;
        private readonly IMoveRepository _repository;

        public BusinessMoveService(FinalProjectContext context, IMapper mapper, IMoveRepository Repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = Repository;
        }
        public async Task<BusinessMoveDto> CreateBusinessMoveAsync(BusinessMoveDto businessMoveDto)
        {
            var businessMove = _mapper.Map<Move>(businessMoveDto);

            // Add the mapped entity to the context and save
            var addedMove = await _repository.AddAsync(businessMove);
            //_context.Moves.Add(businessMove);
            //await _context.SaveChangesAsync();

            // Optionally, map the saved entity back to a DTO for return
            return _mapper.Map<BusinessMoveDto>(businessMove);
        }

        public async Task<ActionResult<List<BusinessMoveDto>>> GetBusinessMoves()
        {
            // Load the related entities explicitly using .Include and map to the DTO
            var businessMoves = await _repository.GetAllBusinessMovesAsync();
                
                //_context.Moves
                //.Include(pm => pm.Addresses) // Include related Addresses collection
                //.Include(pm => pm.Amenities)
                //.Where(pm => pm.Type == "business")/// Include the Amenities navigation property
                //.ToList(); // Ensure query execution to fetch the data

            // Map the result to the PrivateMoveDto list
            var businessMoveDtos = businessMoves
                .Select(businessMove => _mapper.Map<BusinessMoveDto>(businessMove))
                .ToList(); // Materialize the query into a list

            return businessMoveDtos;
        }

        public async Task<BusinessMoveDto> GetBusinessMoveByIdAsync(int id)
        {
            var businessMove = await _repository.GetByIdAsync(id);
            //.Include(pm => pm.Addresses) // Include related Addresses
            //.Include(pm => pm.Amenities) // Include Amenities navigation property
            //.FirstOrDefaultAsync(pm => pm.Id == id); // Find the entity by Id

            if (businessMove == null)
            {
                return null;
            }

            // Map the entity to its corresponding DTO
            return _mapper.Map<BusinessMoveDto>(businessMove);
        }

    }
}
