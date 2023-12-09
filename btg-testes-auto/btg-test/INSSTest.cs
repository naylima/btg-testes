using btg_testes_auto;
using FluentAssertions;

namespace btg_test
{
    public class INSSTest
    {
        /*
        * Realize o Calculo do INSS de um salário utilizando a tabela abaixo
        * Salario até R$ 1.212,00 aliquota de 7,5%
        * até R$ 2.427,35 aliquota de 9%
        * até R$ 3.641,03 aliquota de 12%
        * acima disso aliquota de 14%
        */

        [Fact(DisplayName = "Salario até R$ 1.212,00")]
        [Trait("INSS", "RetornaAliquotaAplicavel")]
        public void RetornarAliquotaAplicavel_Salario1212_Retorna7_5()
        {
            // Arrange
            INSS inss = new(1212);

            // Act
            double result = inss.RetornarAliquotaAplicavel();

            // Assert
            result.Should().Be(7.5);
        }

        [Fact(DisplayName = "Salario até R$ 2.427,35")]
        [Trait("INSS", "RetornaAliquotaAplicavel")]
        public void RetornarAliquotaAplicavel_Salario2427_Retorna9()
        {
            // Arrange
            INSS inss = new(2427.35);

            // Act
            double result = inss.RetornarAliquotaAplicavel();

            // Assert
            result.Should().Be(9);
        }

        [Fact(DisplayName = "Salario até R$ 3.641,03")]
        [Trait("INSS", "RetornaAliquotaAplicavel")]
        public void RetornarAliquotaAplicavel_Salario3641_Retorna12()
        {
            // Arrange
            INSS inss = new(3641.03);

            // Act
            double result = inss.RetornarAliquotaAplicavel();

            // Assert
            result.Should().Be(12);
        }

        [Fact(DisplayName = "Salario acima de R$ 3.641,03")]
        [Trait("INSS", "RetornaAliquotaAplicavel")]
        public void RetornarAliquotaAplicavel_SalarioAcimaDe3641_Retorna14()
        {
            // Arrange
            INSS inss = new(4681.58);

            // Act
            double result = inss.RetornarAliquotaAplicavel();

            // Assert
            result.Should().Be(14);
        }

        [Fact(DisplayName = "Calcular parcela do INSS")]
        [Trait("INSS", "CalcularParcela")]
        public void CalcularParcela_SalarioInformado_RetornaParcelaCalculada()
        {
            // Arrange
            INSS inss = new(1212);

            // Act
            double result = inss.CalcularParcela();

            // Assert
            result.Should().Be(90.9);
        }
    }
}
