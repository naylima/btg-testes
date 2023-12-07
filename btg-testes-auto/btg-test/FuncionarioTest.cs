using btg_testes_auto;
using FluentAssertions;

namespace btg_test
{
    public class FuncionarioTest
    {

        //nomeMetodo_CondicaoCenario_ComportamentoEsperado
        /*
        [Fact]
        public void DefinirNivelProfissional_SalariosVariados_RetornaNivelProfissionalCorreto()
        {
            // Arrange
            List<decimal> salarios = new() { 0, 1500, 1998, 1999, 5000, 7998, 7999, 8000, 9500 };

            foreach (decimal salario in salarios)
            {
                // Act
                Funcionario funcionario = new("Amanda", salario);

                // Assert
                if (salario < 1999)
                    Assert.Equal("Junior", funcionario.NivelProfissional);
                else if (salario < 7999)
                    Assert.Equal("Pleno", funcionario.NivelProfissional);
                else
                    Assert.Equal("Senior", funcionario.NivelProfissional);
            }
        }*/
        /*
        [Fact]
        public void DefinirNivelProfissional_Salarios0_RetornaNivelProfissionalJunior()
        {
            // Arrange
            // Act
            Funcionario funcionario = new("Amanda", 0);

            // Assert
            Assert.Equal("Junior", funcionario.NivelProfissional);
        }
        */

        [Fact(DisplayName = "Salario 1000")]
        [Trait("DefinirNivelProfissional", "ProfissionalJunior")]
        public void DefinirNivelProfissional_Salarios1000_RetornaNivelProfissionalJunior()
        {
            // Arrange
            // Act
            Funcionario funcionario = new("Amanda", 1000);

            // Assert
            Assert.Equal("Junior", funcionario.NivelProfissional);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1500)]
        [InlineData(1998)]
        [Trait("DefinirNivelProfissional", "ProfissionalPleno")]
        public void DefinirNivelProfissional_SalarioAbaixoDe1999_RetornaNivelProfissionalJunior(decimal salario)
        {
            // Arrange
            // Act
            Funcionario funcionario = new("Amanda", salario);

            // Assert
            Assert.Equal("Junior", funcionario.NivelProfissional);

        }

        [Theory]
        [InlineData(1999)]
        [InlineData(5000)]
        [InlineData(7998)]
        public void DefinirNivelProfissional_SalarioAbaixoDe7999_RetornaNivelProfissionalPleno(decimal salario)
        {
            // Arrange
            // Act
            Funcionario funcionario = new("Amanda", salario);

            // Assert
            Assert.Equal("Pleno", funcionario.NivelProfissional);

        }

        //podemos adicionar quantos parametros necessario
        [Theory(DisplayName = "Salario Acima de 7998")]
        [InlineData(7999, 1000)]
        [InlineData(10000, 1000)]
        public void DefinirNivelProfissional_SalarioAcimaDe7998_RetornaNivelProfissionalSenior(decimal salario, decimal salario2)
        {
            // Arrange
            // Act
            Funcionario funcionario = new("Amanda", salario);

            // Assert
            Assert.Equal("Senior", funcionario.NivelProfissional);
            funcionario.NivelProfissional.Should().Be("Senior");
        }

        

    }
}
