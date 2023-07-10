using Domain.Interfaces.Services;
using Domain.Models;
using Service.Services;
using System.Diagnostics.CodeAnalysis;

namespace Test.Services
{
    public class QuestionFourServiceTest
    {

        [Fact]
        public void QuestionFourService_Should_Return_Distinct_Elements_From_Valid_Collection()
        {
            //arrange
            var car1 = new Car() { Id = 1, Name = "Celta", Color = "Red" };
            var car2 = new Car() { Id = 2, Name = "Civic", Color = "Preto" };
            var car3 = new Car() { Id = 1, Name = "Celta", Color = "Red" };
            var cars = new List<Car>() { car1, car2, car3 };

            IQuestionFourService service = new QuestionFourService();

            //act
            var result = service.GetDistictElements(cars);

            //assert
            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(p => p.Name == "Celta"));


        }
    }
}
