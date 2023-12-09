using System;
using btg_testes_auto;
using Xunit;

namespace btg_testes_auto;

public class AnaliseSuspeitosTest
{
    [Theory]
    [InlineData(true, true, false, false, false)] 
    [InlineData(true, false, true, false, false)]
    [InlineData(true, false, false, true, false)]
    [InlineData(true, false, false, false, true)]
    [InlineData(false, true, true, false, false)]
    [InlineData(false, true, false, true, false)]
    [InlineData(false, true, false, false, true)]
    [InlineData(false, false, true, true, false)]
    [InlineData(false, false, true, false, true)]
    [InlineData(false, false, false, true, true)]
    public void ExecutarQuestionarioSuspeito_2RespostasPositivas_RetornaSuspeito(
        bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
    {
        // Arrange
        AnaliseSuspeitos analiseSuspeitos = new();

        // Act
        string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(
            telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

        // Assert
        Assert.Equal("Suspeita", resultado);
    }

    [Theory]
    [InlineData(true, true, true, false, false)]
    [InlineData(true, true, false, true, false)]
    [InlineData(true, true, false, false, true)]
    [InlineData(true, false, true, true, false)]
    [InlineData(true, false, true, false, true)]
    [InlineData(true, false, false, true, true)]
    [InlineData(false, true, true, true, false)]
    [InlineData(false, true, true, false, true)]
    [InlineData(false, true, false, true, true)]
    [InlineData(false, false, true, true, true)]
    public void ExecutarQuestionarioSuspeito_3RespostasPositivas_RetornaCumplice(
        bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
    {
        // Arrange
        AnaliseSuspeitos analiseSuspeitos = new();

        // Act
        string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(
            telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

        // Assert
        Assert.Equal("Cúmplice", resultado);
    }

    [Theory]
    [InlineData(true, true, true, true, false)]
    [InlineData(true, true, true, false, true)]
    [InlineData(true, true, false, true, true)]
    [InlineData(true, false, true, true, true)]
    [InlineData(false, true, true, true, true)]
    public void ExecutarQuestionarioSuspeito_4RespostasPositivas_RetornaCumplice(
        bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
    {
        // Arrange
        AnaliseSuspeitos analiseSuspeitos = new();

        // Act
        string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(
            telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

        // Assert
        Assert.Equal("Cúmplice", resultado);
    }

    [Theory]
    [InlineData(true, true, true, true, true)]
    public void ExecutarQuestionarioSuspeito_5RespostasPositivas_RetornaAssassino(
        bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
    {
        // Arrange
        AnaliseSuspeitos analiseSuspeitos = new();

        // Act
        string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(
            telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

        // Assert
        Assert.Equal("Assassino", resultado);
    }

    [Theory]
    [InlineData(false, false, false, false, false)]
    [InlineData(true, false, false, false, false)] 
    [InlineData(false, true, false, false, false)]
    [InlineData(false, false, true, false, false)]
    [InlineData(false, false, false, true, false)]
    [InlineData(false, false, false, false, true)]
    public void ExecutarQuestionarioSuspeito_OutrasCombinacoes_RetornaInocente(
        bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
    {
        // Arrange
        AnaliseSuspeitos analiseSuspeitos = new();

        // Act
        string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(
            telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

        // Assert
        Assert.Equal("Inocente", resultado);
    }
}

