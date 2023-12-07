using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_testes_auto
{
    public class Motorista
    {
        public string EncontrarMotoristas(List<Pessoa> pessoas)
        {
            List<Pessoa> motoristas = new();
            foreach (var pessoa in pessoas)
            {
                if (pessoa.Idade < 18)
                {
                    continue;
                }

                if (pessoa.PossuiHabilitaçãoB)
                {
                    motoristas.Add(pessoa);
                    if (motoristas.Count == 2)
                    {
                        return $"Uhuu! Os motorista são {motoristas[0].Nome} e {motoristas[1].Nome}";
                    }
                }
            }

            throw new Exception("A viagem não será realizada devido falta de motoristas!");
        }
    }
}
