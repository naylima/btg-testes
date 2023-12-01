using btg_testes_auto;
using System;

namespace btg_test
{
    public class CalculadoraTest
    {
        /*
         * Teste simulando erro
        [Fact]
        public void Somar_NumerosValidos_RetornaNumerosSomados()
        {
            // Arrange
            Calculadora calculadora = new(2, 2);

            // Act
            double resultado = calculadora.Somar();

            // Assert
            Assert.Equal(5, resultado);
        }*/

        [Fact]
        public void Somar_NumerosValidos_RetornaNumerosSomados()
        {
            // Arrange
            Calculadora calculadora = new(2, 2);

            // Act
            double resultado = calculadora.Somar();

            // Assert
            Assert.Equal(4, resultado);
        }

        [Fact]
        public void Somar_ListaValida_RetornaNumerosSomados()
        {
            // Arrange
            List<double> listaValores = new() { 5, 5, 2, 3 };

            Calculadora calculadora = new();

            // Act
            double resultado = calculadora.Somar(listaValores);

            // Assert
            Assert.Equal(15, resultado);
        }

        [Fact]
        public void Subtrair_NumerosValidos_RetornaNumerosSubstraidos()
        {
            // Arrange
            Calculadora calculadora = new()
            {
                numero1 = 5,
                numero2 = 2
            };

            // Act
            double resultado = calculadora.Subtrair();

            // Assert
            Assert.Equal(3, resultado);
        }

        [Fact]
        public void Multiplicar_NumerosValores_RetornaNumerosMultiplicados()
        {
            // Arrange
            Calculadora calculadora = new(2, 2);

            // Act
            double resultado = calculadora.Multiplicar();

            // Assert
            Assert.Equal(4, resultado);
        }

        [Fact]
        public void Dividir_NumerosValidos_RetornaNumeroDividido()
        {
            // Given
            Calculadora calculadora = new(2, 2);

            // When
            double? resultado = calculadora.Dividir();

            // Then
            Assert.Equal(1, resultado);
        }

        // nomeMetodo_CondicaoCenario_ComportamentoEsperado
        [Fact]
        public void Dividir_NumeroInvalido_RetornaExcecao()
        {
            Calculadora calculadora = new(2, 0);
            

            Action resultado2 = () => calculadora.Dividir();
            
            Assert.Throws<Exception>(resultado2);
  
        }

        /*
            double? resultado = calculadora.Dividir();

            Assert.Null(resultado);

            Assert.True(bool);
            Assert.False(bool);

            Assert.Null(objeto);
            Assert.NotNull(objeto);

            Assert.Empty(lista);
            Assert.NotEmpty(lista);

            Assert.StartsWith("esperado", "resultado");
            Assert.EndsWith("esperado", "resultado");
            
            Assert.Contains("esperado", "resultado");
            Assert.DoesNotContain();

            Assert.InRange(150, 100, 200);
            Assert.NotInRange();

            // valida se lista possui 1 objeto
            Assert.Single();

            */
    }
}