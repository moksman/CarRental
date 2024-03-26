using Xunit;
using FluentAssertions;
using CarRental.Core.Domain;
using System;

namespace CarRental.UnitTest
{
    public class CityTests
    {
        [Fact]
        public void Create_ShouldReturnCityWithGivenIdAndName()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var name = "Test City";

            // Act
            var city = City.Create(id, name);

            // Assert
            city.Should().NotBeNull();
            city.Name.Should().Be(name);
            // Assuming Entity base class has an Id property
            city.Id.Should().Be(id);
        }

        [Fact]
        public void IsSelected_ShouldBeFalseByDefault()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var name = "Test City";
            var city = City.Create(id, name);

            // Act
            var isSelected = city.IsSelected;

            // Assert
            isSelected.Should().BeFalse();
        }

        [Fact]
        public void IsSelected_ShouldBeAbleToSetTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var name = "Test City";
            var city = City.Create(id, name);

            // Act
            city.IsSelected = true;

            // Assert
            city.IsSelected.Should().BeTrue();
        }
    }
}
