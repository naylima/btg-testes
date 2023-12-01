namespace btg_testes_auto
{
    public class MediaIdades
    {
        // teste unitario alunas
        public decimal CalculaMedia(List<int> idades)
        {
            // Programa que calcula a idade média de um grupo de pessoas
            // Se a idade for menor que 18, não utilize na média.

            List<int> idadesMaiorQue18 = idades.Where(x => x >= 18).ToList();

            return idadesMaiorQue18.Sum() / idadesMaiorQue18.Count;
        }
    }
}
