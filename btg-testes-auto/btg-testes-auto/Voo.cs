using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_testes_auto
{
    public class Voo
    {
        private string Aeronave { get; set; }
        private string NumeroVoo { get; set; }
        private DateTime DataHora { get; set; }
        private int QuantidadeTotalPassageiros { get; set; }
        private List<Assento> Assentos { get; set; }
        public Voo(string aeronave, string numeroVoo, DateTime dataHora)
        {
            Aeronave = aeronave;
            NumeroVoo = numeroVoo;
            DataHora = dataHora;
            QuantidadeTotalPassageiros = 100;
            Assentos = new();
            for (int i = 0; i < QuantidadeTotalPassageiros; i++)
            {
                Assentos.Add(new Assento(i));
            }
        }

        public int ProximoLivre()
        {
            if (QuantidadeVagasDisponivel() == 0)
            {
                return 0;
            }

            return Assentos.FirstOrDefault(x => !x.Ocupado).Posicao;
        }

        public bool AssentoDisponivel(int posicao)
        {
            return Assentos.Any(x => x.Posicao == posicao && !x.Ocupado);
            //return !Assentos[posicao].Ocupado;
        }

        public bool OcupaAssento(int posicao)
        {
            if (!AssentoDisponivel(posicao))
            {
                return false;
            }
            Assentos[posicao].Ocupado = true;
            return true;
        }

        public int QuantidadeVagasDisponivel()
        {
            return Assentos.Count(x => !x.Ocupado);
        }

        public string ExibeInformacoesVoo()
        {
            return $"Aeronave {Aeronave} registrada sob voo de número {NumeroVoo} para o dia e hora {DataHora}";
        }
    }

    public class Assento
    {
        public int Posicao { get; set; }
        public bool Ocupado { get; set; }
        public Assento(int posicao)
        {
            Posicao = posicao;
        }
    }
}
