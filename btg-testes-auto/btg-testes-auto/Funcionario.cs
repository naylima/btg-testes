namespace btg_testes_auto
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public string NivelProfissional { get; private set; }

        public Funcionario(string nome, decimal salario)
        {
            Nome = nome;
            Salario = salario;
            NivelProfissional = DefinirNivelProfissional();
        }

        public string DefinirNivelProfissional()
        {
            if (Salario < 1999)
            {
                return "Junior";
            }
            else if (Salario < 7999)
            {
                return "Pleno";
            }
            else
            {
                return "Senior";
            }
        }
    }
}
