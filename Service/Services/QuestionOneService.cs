using Domain.Interfaces.Services;

namespace Service.Services
{
    public class QuestionOneService : IQuestionOneService
    {

        public QuestionOneService()
        {
            
        }

        public string GetNumberInWords(int value)
        {
            if (value > 999999999 || value < -999999999)
                throw new ArgumentException("valor maior do que o permitido");
            return GetNumberInWordsInternal(value).Trim();
        }

        private string GetNumberInWordsInternal(int value)
        {
            if(value == 0)
            {
                return "zero";
            }
            else if (value < 0)
            {
                return $"menos {GetNumberInWordsInternal(Math.Abs(value))}"; //recursão com o valor absoluto para evitar um loop infinito.
            }

            string numberInWords = "";
            if ((value / 1000000) > 0)
            {
                var result = value / 1000000;
                numberInWords += GetNumberInWordsInternal(result) + (result >= 2 ? "milhões ":"milhão ");
                value %= 1000000;
            }

            if ((value / 1000) > 0)
            {
                var result = value / 1000;
                numberInWords += result >= 2 ? GetNumberInWordsInternal(result) + "mil " : " mil ";
                value %= 1000;
            }

            if (value == 100)
            {
                numberInWords += numberInWords != "" ? "e cem" : "cem";
                value %= 100;
            }
            else if ((value / 100) > 0)
            {
                string[] centenas = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

                numberInWords += centenas[value / 100] + " ";
                value %= 100;
            }

            if (value > 0)
            {
                if (numberInWords != "")
                {
                    numberInWords += "e ";
                }

                string[] unidades = { "", "um ", "dois ", "três ", "quatro ", "cinco ", "seis ", "sete ", "oito ", "nove ", "dez ", "onze ", "doze ", "treze ", "quatorze ", "quinze ", "dezesseis ", "dezessete ", "dezoito ", "dezenove " };
                string[] dezenas = { "", "", "vinte ", "trinta ", "quarenta ", "cinquenta ", "sessenta ", "setenta ", "oitenta ", "noventa " };

                if (value < 20)
                {
                    numberInWords += unidades[value];
                }
                else
                {
                    numberInWords += dezenas[value / 10];
                    if ((value % 10) > 0)
                    {
                        numberInWords += "e " + unidades[value % 10];
                    }
                }
            }

            return numberInWords;
        }
    }
}
