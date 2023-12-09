using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_testes_auto
{
    public class INSS
    {
        /*
       * Realize o Calculo do INSS de um salário utilizando a tabela abaixo
       * Salario até R$ 1.212,00 aliquota de 7,5%
       * até R$ 2.427,35 aliquota de 9%
       * até R$ 3.641,03 aliquota de 12%
       * acima disso aliquota de 14%
       */
        public double Salario { get; set; }
        public INSS(double salario)
        {
            Salario = salario;
        }

        public double RetornarAliquotaAplicavel()
        {
            if (Salario <= 1212)
                return 7.5;
            else if (Salario <= 2427.35)
                return 9;
            else if (Salario <= 3641.03)
                return 12;
            else
                return 14;
        }

        public double CalcularParcela()
        {
            double aliquotaAplicavel = RetornarAliquotaAplicavel();

            return Salario * aliquotaAplicavel / 100;
        }
    }
}
