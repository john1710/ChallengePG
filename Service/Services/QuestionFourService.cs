using Domain.Helpers;
using Domain.Interfaces.Services;

namespace Service.Services
{
    public class QuestionFourService : IQuestionFourService
    {
        public IEnumerable<T> GetDistictElements<T>(List<T> elements) where T : class
        {
            return elements.Distinct(new CompareByProperties<T>()); 
        }
    }

}
