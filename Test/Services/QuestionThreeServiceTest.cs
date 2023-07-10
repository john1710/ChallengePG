using Domain.Interfaces.Services;
using Service.Services;

namespace Test.Services
{
    public class QuestionThreeServiceTest
    {
        [Theory]
        [InlineData("1 + 1", 2)]
        [InlineData("1 + 1 * 2", 3)]
        [InlineData("1 + 1 * 2 / 4", 1.5f)]
        [InlineData("1 - 3", -2)]
        [InlineData("5 / 10", .5f)]
        [InlineData("1,5 * 2", 3)]
        [InlineData("5 - 5 + 5", 5)]
        [InlineData("8 + 8 - 4 * 6", -8)]

        void QuestionThreeService_Should_Pass_With_Valid_Arguments(string expression, float expected)
        {
            //arrange
            IQuestionThreeService service = new QuestionThreeService();

            //act
            var result = service.ExecuteExpression(expression);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("+ 2")]
        [InlineData("5 *")]
        [InlineData("98 @ 56")]
        [InlineData("800 / 0")]
        [InlineData("0 / 999999")]
        [InlineData("23x * 74")]
        void QuestionThreeService_Should_Fail_With_Invalid_Arguments(string expression)
        {
            //arrange
            IQuestionThreeService service = new QuestionThreeService();

            //act assert
            Assert.Throws<ArgumentException>(() => service.ExecuteExpression(expression));
        }
    }
}
