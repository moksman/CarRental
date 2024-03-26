using CarRental.Application.Abstractions;
using CarRental.Application.Configuration;
using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;


namespace CarRental.Application.UseCases.Car.Queries.Get
{

    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IEnumerable<CarDto>>
    {
        //private readonly IService<Core.Domain.Car> _carService;
        private readonly IBaseRepository<Core.Domain.Car, Guid> _repository;
        private readonly IMemoryCache _cache;
        private readonly CarMapper _mapper;


        //public GetAllCarQueryHandler(IService<Core.Domain.Car> carService, IBaseRepository<Core.Domain.Car> repository, IMemoryCache cache)
        public GetAllCarQueryHandler(IBaseRepository<Core.Domain.Car, Guid> repository, CarMapper mapper, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarDto>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            if (_cache.TryGetValue("CarList", out IList<CarDto> listOfAllCars))
                return listOfAllCars;

            CarMapper mapper = new();

            listOfAllCars = (await _repository.GetAll())
                .Select(c => mapper.CarToCarDto(c))
                .ToList();

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _cache.Set("CarList", listOfAllCars, cacheEntryOptions);


            return listOfAllCars;            
        }

    }
}
