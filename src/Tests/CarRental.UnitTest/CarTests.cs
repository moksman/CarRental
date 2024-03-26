using CarRental.Core.Domain;
using CarRental.Core.Enums;
using FluentAssertions;

namespace CarRental.UnitTest;

public class CoreTests
{
    [Theory]
        
    [InlineData("5605ed93-e7d3-47fb-9a0d-2832b0ab267f", "5605ed93-e7d3-47fb-9a0d-2832b0ab267f", " ", "G63", "Upptäck Peugeot 3008 och dess unika revolutionerande stil. Med Peugeot i-Cockpit® och innovativ teknik i framkant förstärks ditt välbefinnande, din säkerhet och din komfort.", 4, 180, VehiculeType.COUPE, TransmissionType.AUTOMATIC)]
    [InlineData("5605ed93-e7d3-47fb-9a0d-2832b0ab267f", "5605ed93-e7d3-47fb-9a0d-2832b0ab267f", "Mercedes", " ", "Upptäck Peugeot 3008 och dess unika revolutionerande stil. Med Peugeot i-Cockpit® och innovativ teknik i framkant förstärks ditt välbefinnande, din säkerhet och din komfort.", 4, 180, VehiculeType.COUPE, TransmissionType.AUTOMATIC)]
    [InlineData("5605ed93-e7d3-47fb-9a0d-2832b0ab267f", "5605ed93-e7d3-47fb-9a0d-2832b0ab267f", "Mercedes", "G63", " ", 4, 180, VehiculeType.COUPE, TransmissionType.AUTOMATIC)]
    public void Contstructur_Check_Empty_String_Test(Guid carId, Guid cityId, string Brand, string Model, string Description, int Seats, decimal Price, VehiculeType VehiculeType, TransmissionType TransmissionType)
    {
        Car Action() => Car.Create(carId, cityId, Brand, Model, Description, "", Seats, Price, VehiculeType, TransmissionType);

        //Assert
        FluentActions.Invoking(Action)
            .Should()
            .Throw<ArgumentException>();
    }

    //create test for domain event
    [Fact]
    public void Create_ShouldReturnCarWithGivenIdAndName()
    {
        // Arrange
        var id = Guid.NewGuid();
        var cityId = Guid.NewGuid();
        var brand = "Mercedes";
        var model = "G63";
        var description = "Upptäck Peugeot 3008 och dess unika revolutionerande stil. Med Peugeot i-Cockpit® och innovativ teknik i framkant förstärks ditt välbefinnande, din säkerhet och din komfort.";
        var noOfSeats = 4;
        var price = 180;
        var type = VehiculeType.COUPE;
        var transmission = TransmissionType.AUTOMATIC;

        // Act
        var car = Car.Create(id, cityId, brand, model, description, "", noOfSeats, price, type, transmission);

        // Assert
        car.DomainEvents.Should().NotBeEmpty();
        car.Should().NotBeNull();
        car.Brand.Should().Be(brand);
        car.Model.Should().Be(model);
        car.Description.Should().Be(description);
        car.NoOfSeats.Should().Be(noOfSeats);
        car.Price.Should().Be(price);
        car.Type.Should().Be(type);
        car.Transmission.Should().Be(transmission);
        // Assuming Entity base class has an Id property
        car.Id.Should().Be(id);
    }

}