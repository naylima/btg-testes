namespace btg_testes_auto
{
    public class Calculadora
    {
        public double numero1;
        public double numero2;

        public Calculadora()
        {
        }

        public Calculadora(double numero1, double numero2)
        {
            this.numero1 = numero1;
            this.numero2 = numero2;
        }

        public double Somar()
        {
            return numero1 + numero2;
        }

        public double Somar(List<double> valores)
        {
            return valores.Sum();
        }

        public double Subtrair()
        {
            return numero1 - numero2;
        }

        public double Multiplicar()
        {
            return numero1 * numero2;
        }

        public double Dividir()
        {
            if (numero2 == 0)
            {
                throw new Exception("Mensagem exception");
            }

            return numero1 / numero2;
        }
    }
}
