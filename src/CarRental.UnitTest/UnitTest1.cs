using Core.Model;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var forecast = new Core.Model.WeatherForecast<int>();
            
            //Act
            forecast.Id = 1;

            //Assert
            Assert.Equal(1, forecast.Id);
        }
    }
}