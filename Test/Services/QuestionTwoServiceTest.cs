using Domain.Interfaces.Services;
using Service.Services;

namespace Test.Services
{
    public class QuestionTwoServiceTest
    {
        [Fact]
        void QuestionTwoService_Should_Pass_With_Valid_Numbers()
        {
            //arrange
            var array = new int[1000000];
            var random = new Random();
            var total = 0f;
            for (int i = 0; i < array.Length; i++)
            {
                var aux = random.Next();
                array[i] = aux;
                total += aux;
            }
            IQuestionTwoService service = new QuestionTwoService();

            //act
            var result = service.GetTotalSum(array);

            //assert
            Assert.Equal(total, result);
        }

        [Fact]
        void QuestionTwoService_Should_Pass_With_Max_of_int_on_each_element_of_array()
        {
            //arrange
            var array = new int[1000000];
            var total = 0f;
            for (int i = 0; i < array.Length; i++)
            {
                var aux = int.MaxValue;
                array[i] = aux;
                total += aux;
            }
            IQuestionTwoService service = new QuestionTwoService();

            //act
            var result = service.GetTotalSum(array);

            //assert
            Assert.Equal(total, result);
        }

        [Fact]
        void QuestionTwoService_Should_Fail_When_Array_size_is_Greater_Than_One_Million()
        {
            //arrange
            var array = new int[1000001];
            var total = 0f;
            for (int i = 0; i < array.Length; i++)
            {
                var aux = int.MaxValue;
                array[i] = aux;
                total += aux;
            }
            IQuestionTwoService service = new QuestionTwoService();

            //act
            //act assert
            Assert.Throws<ArgumentException>(() => service.GetTotalSum(array));
        }

        [Fact]
        void QuestionTwoService_Should_Fail_When_Array_is_null()
        {
            //arrange
            IQuestionTwoService service = new QuestionTwoService();

            //act
            //act assert
            Assert.Throws<NullReferenceException>(() => service.GetTotalSum(null));
        }
    }
}
