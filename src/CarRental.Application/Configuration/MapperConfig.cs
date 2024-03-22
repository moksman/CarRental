using CarRental.Application.UseCases.Car;
using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using Riok.Mapperly.Abstractions;

namespace CarRental.Application.Configuration;




[Mapper]
public partial class CarMapper
{
    public partial CarDto CarToCarDto(Car car);
}


[Mapper]
public partial class CityMapper
{
    public partial CityDto CityToDto(City city);
}




