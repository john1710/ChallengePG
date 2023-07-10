# ChallengePG
**A solution Consiste em três projetos: uma camada de dominio, uma de serviço e outra de testes. Para cada questão foi criado um Serviço com o respectivo nome para facilitar a leitura.**

# Questão 01:
 Como você implementou a função que retorna a representação por extenso
do número no desafio 1? Quais foram os principais desafios encontrados?

R> **fiz uma implementação visando recursão e dividir pra conquistar, separei os milhoes, das milhares e os isolei do restante. não teve grandes desafios mas so havia pontos de maiores atenções em tratamento especiais ex: quando o 100 ta isolado deve ser chamado de cem e não de cento, milhao deve ser pluralizado acima de 1**

# Questão 02:
Como você lidou com a performance na implementação do desafio 2,
considerando que o array pode ter até 1 milhão de números?

R> **Sinto que tinha alguma pegadinha por trás desse desafio aqui que não saquei, contudo para esse desafio decidi fazer uma implementação onde o resultado era float, pois dessa forma mesmo que cada elemento do possivel milhao de elementos do array fosse o maior numero possivel em um inteiro, o float ainda seria capaz de comportar o resultado. já na implementação da soma usei um for para fazer da forma mais direta possivel, ao indes de usar o Sum do linq que teria um custo de processamento um pouco maior.**

# Questão 03:
 Como você lidou com os possíveis erros de entrada na implementação do
desafio 3, como uma divisão por zero ou uma expressão inválida?

R>**Usei validação através de regular expression para gerar expceptions controladas para as possiveis casualidades**

# Questões 04:
como você implementou a função que remove objetos repetidos na
implementação do desafio 4? Quais foram os principais desafios
encontrados?

R>**Essa aqui existe uma grande variedade de soluções, no entanto achei que faltou mais descrição na questão, pois o que seria unico? unico em referencia, unico em uma propriedade ou em todas? contudo presumi que fosse em todas, e pra isso  utilizei a implementação mais limpa e que poderia ser usada para outros tipos de objetos, então usei o Distinct do Linq aliada do IEqualityComparer e Reflections do C#** 
