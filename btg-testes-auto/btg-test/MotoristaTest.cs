using System;
using System.Collections.Generic;
using btg_testes_auto;

namespace btg_test;

public class MotoristaTest
{
    [Fact]
    public void EncontrarMotoristas_DoisMotoristasHabilitadosMaioresde18_RetornaMensagemComNomes()
    {
        // Arrange
        List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "João", Idade = 20, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 18, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Ana", Idade = 22, PossuiHabilitaçãoB = false }
        };

        Motorista motorista = new Motorista();

        // Act
        string resultado = motorista.EncontrarMotoristas(pessoas);

        // Assert
        Assert.Contains("João", resultado);
        Assert.Contains("Maria", resultado);
    }

    [Fact]
    public void EncontrarMotoristas_MenosDeDoisMotoristasHabilitadosMaioresde18_GeraException()
    {
        // Arrange
        List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "João", Idade = 20, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 25, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "Carlos", Idade = 17, PossuiHabilitaçãoB = true }
        };

        Motorista motorista = new Motorista();

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => motorista.EncontrarMotoristas(pessoas));
        Assert.Equal("A viagem não será realizada devido falta de motoristas!", exception.Message);
    }
}
