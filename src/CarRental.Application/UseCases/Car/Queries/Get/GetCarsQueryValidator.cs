using FluentValidation;

namespace CarRental.Application.UseCases.Car.Queries.Get;

// Path: src/CarRental.Application/UseCases/Car/Get/GetCarsQueryValidator.cs
//using FluentValidation;

//namespace CarRental.Application.Validator;
public class GetCarsQueryValidator : AbstractValidator<GetCarsQuery>
{
    public GetCarsQueryValidator()
    {
        RuleFor(x => x.VehiculeType).IsInEnum();
        RuleFor(x => x.TransmissionType).IsInEnum();
        RuleFor(x => x.Passangers).GreaterThan(0);
        RuleFor(x => x.CountryIds).NotEmpty();
    }
}