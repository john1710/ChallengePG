using Domain.Interfaces.Services;
using Service.Services;

namespace Test.Services
{
    public class QuestionOneServiceTest
    {

        [Theory]
        [InlineData(0,"zero")]
        [InlineData(32,"trinta e dois")]
        [InlineData(1010,"mil e dez")]
        [InlineData(88,"oitenta e oito")]
        [InlineData(5,"cinco")]
        [InlineData(100,"cem")]
        [InlineData(132,"cento e trinta e dois")]
        [InlineData(2100,"dois mil e cem")]
        [InlineData(690,"seiscentos e noventa")]
        [InlineData(450852,"quatrocentos e cinquenta mil oitocentos e cinquenta e dois")]
        [InlineData(900325875,"novecentos milhões trezentos e vinte e cinco mil oitocentos e setenta e cinco")]
        [InlineData(-900325875,"menos novecentos milhões trezentos e vinte e cinco mil oitocentos e setenta e cinco")]
        [InlineData(999999999,"novecentos e noventa e nove milhões novecentos e noventa e nove mil novecentos e noventa e nove")]
        void QuestionOneService_Should_Pass_With_Valid_Numbers(int value, string expected)
        {
            //arrange
            IQuestionOneService service = new QuestionOneService();

            //act
            var result = service.GetNumberInWords(value);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1111111111)]
        [InlineData(-1111111111)]
        void QuestionOneService_Should_Fail_When_Value_Is_Greater_Or_Less_Than_Limit(int value)
        {
            //arrange
            IQuestionOneService service = new QuestionOneService();

            //act assert
            Assert.Throws<ArgumentException>(() => service.GetNumberInWords(value));
        }
    }
}
