using CarRental.Application.Interfaces;
using CarRental.Core.Model;
using MediatR;

namespace CarRental.Application.UseCases.City.Get
{

    public class GetAllCItyQueryHandler<TId> : IRequestHandler<GetAllCityQuery<TId>, IEnumerable<City<TId>>>
    {
        private readonly IBaseRepository<City<TId>, TId> _repository;


        public GetAllCItyQueryHandler(IBaseRepository<City<TId>, TId> baseRepository)
        {
            _repository = baseRepository;
        }
        public async Task<IEnumerable<City<TId>>> Handle(GetAllCityQuery<TId> request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }

    }
}
