namespace btg_testes_auto
{
    public class MediaNotas
    {
        // testes unitario alunas
        public string CalculaMedia(List<decimal> notas, decimal? notaRecuperacao)
        {
            // Escreva um programa que leia quatro notas escolares de um aluno e
            // apresentar uma mensagem que o aluno foi aprovado se o valor da média escolar
            // for maior ou igual a 7.
            // Se o valor da média for menor que 7, solicitar a nota do recuperação,
            // somar com o valor da média e obter a nova média.
            // Se a nova média for maior ou igual a 7,
            // apresentar uma mensagem informando que o aluno foi aprovado na recuperação.
            // Se o aluno não foi aprovado, apresentar uma mensagem informando esta condição.
            // Apresentar junto com as mensagens o valor da média do aluno.

            var media = notas.Sum() / notas.Count;

            if (media < 7)
            {
                if (notaRecuperacao is not null)
                {
                    media = (media + notaRecuperacao.Value) / 2;
                }

                if (media >= 7)
                {
                    return $"Parabéns! Você foi aprovado na recuperação! Sua média é: {media}";
                }
                else
                {
                    return $"Infelizmente você não foi aprovado na recuperação :(. Sua média é: {media}";
                }
            }
            else
            {
                return $"Parabéns, você foi aprovado! Sua média é: {media}";
            }
        }
    }
}
