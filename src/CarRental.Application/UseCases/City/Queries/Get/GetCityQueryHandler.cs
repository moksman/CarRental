using AutoMapper;
using CarRental.Application.Abstractions;
using CarRental.Application.Configuration;
using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using MediatR;

namespace CarRental.Application.UseCases.City.Queries.Get
{

    public class GetAllCityQueryHandler : IRequestHandler<GetAllCityQuery, IEnumerable<CityDto>>
    {
        private readonly IBaseRepository<Core.Domain.City, CityId> _repository;
        private readonly CityMapper _mapper;

        public GetAllCityQueryHandler(IBaseRepository<Core.Domain.City, CityId> baseRepository, CityMapper mapper)
        {
            _repository = baseRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CityDto>> Handle(GetAllCityQuery request,  CancellationToken cancellationToken)
        {
            return (await _repository.GetAll())
                .Select(c => _mapper.CityToDto(c));
        }

    }
}
