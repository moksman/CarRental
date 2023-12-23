namespace CarRental.Application.UseCases.Car;

//public record WeatherForecast : Entity<EntityId>
public record CarDto
{
    public CarDto()
    {
    }

    public CarDto(int id, DateOnly date, int temperatureC, string summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


