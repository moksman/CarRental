using CarRental.Application.UseCases.Car.Queries.Get;
using CarRental.Application.UseCases.City.Queries.Get;
using CarRental.Application.UseCases.Dto;
using CarRental.Core.Domain;
using Microsoft.AspNetCore.Components;

namespace CarRental.Server.Components.Pages.Car;

public partial class Index 
{

    [SupplyParameterFromQuery]
    public string? City { get; set; }

    public IEnumerable<CityDto> Cities { get; set; }

    public IEnumerable<CarDto>? Cars;

    public DateTime date;

    private enum SearchParameter
    {
        VehiculeTypeSport,
        VehiculeTypeCoupe,
        TransmissionTypeAuto,
        TransmissionTypeManual,
        PassengersTwo,
        PassengersFour
    }

    IList<string> SearchParametersActive { get; set; } = new List<string>();
           

    int CalculateDatesBetween(DateTime startDate, DateTime endDate)
    {
        return (int)(endDate - startDate).TotalDays;
    }

    protected override async Task OnInitializedAsync()
    {

        Cities = await Mediator.Send(new GetAllCityQuery());
        // if (Guid is null)
        Cars = await Mediator.Send(new GetAllCarQuery());
        // else

        // Cars = await Mediator.Send(new GetCarByCityQuery<int>(Guid));
        
    }

    void SetSearchParameterItemActive(SearchParameter para)
    {
        if (SearchParametersActive.Contains(para.ToString()))
            SearchParametersActive.Remove(para.ToString());
        else
            SearchParametersActive.Add(para.ToString());

        FilterSearch();

    }

    public async Task FilterSearch()
    {
        var carsQuery = new GetCarsQuery();

        //create list with students     

        // IEnumerable<Func<bool>> conditions = 

        // foreach (var s in SearchParametersActive)
        // {
        //     if (s is SearchParameter.PassengersTwo || s is SearchParameter.PassengersFour)
        //     {
        //         if (s is SearchParameter.PassengersTwo)
        //             carsQuery.Passangers = 2;
        //         else
        //             carsQuery.Passangers = 4;
        //     }

        //     if (s is SearchParameter.TransmissionTypeAuto || s is SearchParameter.TransmissionTypeManual)
        //     {
        //         if (s is SearchParameter.PassengersTwo)
        //             carsQuery.Passangers = 2;
        //         else
        //             carsQuery.Passangers = 4;
        //     }
        // }

    }

    public void ToggleSearchCityAsActive(City city)
    {
        city.IsSelected = !city.IsSelected;
    }

}