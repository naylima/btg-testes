using System;
using btg_testes_auto;
namespace btg_test;

public class LucroTest
{
	[Fact]
    public void Calcular_ValorProdutoMenorQue20_RetornaLucro()
	{
		// Arrange
		Lucro lucro = new();
		decimal valorProduto = 19.99M;

		// Act
		decimal resultado = lucro.Calcular(valorProduto);

		//Assert
		Assert.Equal(28.9855M, resultado);
	}

    [Fact]
    public void Calcular_ValorProdutoIgualA20_RetornaLucro()
    {
        // Arrange
        Lucro lucro = new();
        decimal valorProduto = 20.00M;

        // Act
        decimal resultado = lucro.Calcular(valorProduto);

        // Assert
        Assert.Equal(26.00M, resultado);
    }

    [Fact]
    public void Calcular_ValorProdutoMaiorQue20_RetornaLucro()
    {
        // Arrange
        Lucro lucro = new();
        decimal valorProduto = 25.00M;

        // Act
        decimal resultado = lucro.Calcular(valorProduto);

        // Assert
        Assert.Equal(32.50M, resultado);
    }
}


