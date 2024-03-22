using AutoMapper;
using CarRental.Application.Abstractions;
using CarRental.Application.Configuration;
using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using MediatR;

namespace CarRental.Application.UseCases.Car.Queries.Get
{

    public class GetCarByCityQueryHandler : IRequestHandler<GetCarByCityQuery, IEnumerable<CarDto>>
    {
        //private readonly IService<Core.Domain.Car> _carService;
        private readonly IBaseRepository<Core.Domain.Car, CarId> _repository;
        private readonly CarMapper _mapper;

        //public GetCarByCityQueryHandler(IService<Core.Domain.Car> carService)
        public GetCarByCityQueryHandler(IBaseRepository<Core.Domain.Car, CarId> repository, CarMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarDto>> Handle(GetCarByCityQuery request, CancellationToken cancellationToken)
        {
            return (await _repository.GetAll())
                .Select(c => _mapper.CarToCarDto(c) );
        }

    }
}
