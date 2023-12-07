namespace btg_testes_auto
{
    public class MeiaCinema
    {
        // sugestão Theory/InlineData
        /*
             * O Cinema Ada é uma franquia nacional e disponibiliza valor de meia entrada nas seguintes condições:
            Estudante;
            Doador de sangue;
            Trabalhador da prefeitura e a prefeitura possui contrato firmado com o cinema.
            Realize um questionário S e N e exiba se a pessoa tem direito a meia entrada ou não.
            */
        public bool VerificarMeiaCinema(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            if (estudante ||
                doadorDeSangue ||
                (trabalhadorPrefeitura && contratoPrefeitura))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
