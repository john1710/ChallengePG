using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IQuestionFourService
    {

        public IEnumerable<T> GetDistictElements<T>(List<T> elements) where T : class;
    }
}
