using Domain.Interfaces.Services;
using System.Text.RegularExpressions;

namespace Service.Services
{
    public class QuestionThreeService : IQuestionThreeService
    {
        public float ExecuteExpression(string exp)
        {
            if (Regex.IsMatch(exp, ".*[a-zA-Z].*"))
                throw new ArgumentException("a expressão não pode conter letras.");

            if(Regex.IsMatch(exp, @"[^+\-/*.,\w\s]")) // qualquer simbolo diferente de: + - / *
                throw new ArgumentException("a expressão contem caracteres invalidos.");

            if(Regex.IsMatch(exp, @"0\s*/|/\s*0")) // divisao por zero.
                throw new ArgumentException("a expressão é inválida.");  
            
            if(Regex.IsMatch(exp, @"^[^\d]|[^\d]$")) // começa ou termina com qualquer caractere diferente de numero
                throw new ArgumentException("a expressão é inválida.");

            var terms = exp.Split(' ').ToList();
            var finalResult = 0f;
            while (terms.Count > 1)
            {
                if (terms.Any(p => p == "/" || p == "*"))
                {
                    for (int i = 0; i < terms.Count; i++)
                    {
                        if (terms[i] == "*" || terms[i] == "/")
                        {
                            ExecuteOperation(terms, i);
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < terms.Count; i++)
                    {
                        if (terms[i] == "-" || terms[i] == "+")
                        {
                            ExecuteOperation(terms, i);
                            break;
                        }
                    }
                }
                if (terms.Count == 1)
                    finalResult = float.Parse(terms[0]);
            }

            return finalResult;
        }

        private void ExecuteOperation(List<string> terms, int index)
        {
            if (index == 0 || index == terms.Count)
                throw new ArgumentException("a expressão é inválida.");

            var previous = float.Parse(terms[index - 1]);
            var next = float.Parse(terms[index + 1]);
            var result = 0f;
            switch (terms[index])
            {
                case "+":
                    result = previous + next;
                    break;
                case "-":
                    result = previous - next;
                    break;
                case "*":
                    result = previous * next;
                    break;
                case "/":
                    result = previous / next;
                    break;
            }

            terms.RemoveAt(index - 1);
            terms.RemoveAt(index - 1);
            terms[index - 1] = result.ToString();
        }
    }
}
