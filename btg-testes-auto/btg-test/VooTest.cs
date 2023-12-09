using System;
using System.Collections.Generic;
using btg_testes_auto;

namespace btg_test;

public class VooTest
{
    [Fact]
    public void ProximoLivre_QuandoVooCheio_DeveRetornarZero()
    {
        // Arrange
        Voo voo = new Voo("Boeing 747", "123", DateTime.Now);
        PreencherTodosOsAssentos(voo);

        // Act
        int resultado = voo.ProximoLivre();

        // Assert
        Assert.Equal(0, resultado);
    }

    //nao tá passando !!
    [Fact]
    public void ProximoLivre_QuandoVooComVagas_DeveRetornarProximaPosicaoLivre()
    {
        // Arrange
        Voo voo = new Voo("Airbus A320", "456", DateTime.Now);

        // Act
        voo.ProximoLivre();
        int proximoAssento = voo.ProximoLivre();

        // Assert
        Assert.Equal(1, proximoAssento);
    }

    [Fact]
    public void AssentoDisponivel_QuandoAssentoLivre_DeveRetornarTrue()
    {
        // Arrange
        Voo voo = new Voo("Boeing 777", "789", DateTime.Now);

        // Act
        bool resultado = voo.AssentoDisponivel(2);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void AssentoDisponivel_QuandoAssentoOcupado_DeveRetornarFalse()
    {
        // Arrange
        Voo voo = new Voo("Boeing 787", "101", DateTime.Now);
        voo.OcupaAssento(3);

        // Act
        bool resultado = voo.AssentoDisponivel(3);

        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void OcupaAssento_QuandoAssentoDisponivel_DeveOcuparAssentoEretornarTrue()
    {
        // Arrange
        Voo voo = new Voo("Airbus A380", "202", DateTime.Now);

        // Act
        bool resultado = voo.OcupaAssento(4);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void OcupaAssento_QuandoAssentoOcupado_DeveRetornarFalse()
    {
        // Arrange
        Voo voo = new Voo("Embraer E195", "303", DateTime.Now);
        voo.OcupaAssento(5);

        // Act
        bool resultado = voo.OcupaAssento(5);

        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void QuantidadeVagasDisponivel_QuandoVooCheio_DeveRetornarZero()
    {
        // Arrange
        Voo voo = new Voo("Airbus A330", "404", DateTime.Now);
        PreencherTodosOsAssentos(voo);

        // Act
        int resultado = voo.QuantidadeVagasDisponivel();

        // Assert
        Assert.Equal(0, resultado);
    }

    [Fact]
    public void QuantidadeVagasDisponivel_QuandoVooComVagas_DeveRetornarQuantidadeVagas()
    {
        // Arrange
        Voo voo = new Voo("Airbus A350", "505", DateTime.Now);

        // Act
        int resultado = voo.QuantidadeVagasDisponivel();

        // Assert
        Assert.Equal(100, resultado);
    }

    [Fact]
    public void ExibeInformacoesVoo_DeveRetornarStringComInformacoesDoVoo()
    {
        // Arrange
        Voo voo = new Voo("Boeing 737", "606", DateTime.Now);

        // Act
        string resultado = voo.ExibeInformacoesVoo();

        // Assert
        Assert.Contains("Boeing 737", resultado);
        Assert.Contains("606", resultado);
    }

    private static void PreencherTodosOsAssentos(Voo voo)
    {
        for (int i = 0; i < 100; i++)
        {
            voo.OcupaAssento(i);
        }
    }
}
