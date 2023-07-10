using Domain.Interfaces.Services;

namespace Service.Services
{
    public class QuestionTwoService : IQuestionTwoService
    {
        public float GetTotalSum(int[] values)
        {
            if (values.Length > 1000000) throw new ArgumentException("tamanho da coleção maior que o permitido.");

            // return values.sum(p => p)   <------ é o jeito mais simples em termos de escrita, no entanto não é mais performatico que o metodo usado abaixo.
            var total = 0f;
            for (int i = 0; i < values.Length; i++) { 
                total += values[i];
            }
            return total;
        }
    }
}
