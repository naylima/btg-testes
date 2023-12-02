using btg_testes_auto;

namespace btg_test
{
    public class MediaIdadesTest
    {
        // nomeMetodo_CondicaoCenario_ComportamentoEsperado():

        [Fact]
        public void CalculaMedia_ListaIdadesMaiorQue18_RetornaMedia()
        {
            // Arrange
            MediaIdades mediaIdade = new();

            List<int> idades = new() { 18, 20, 22 };

            // Act
            decimal retorno = mediaIdade.CalculaMedia(idades);

            // Assert
            Assert.Equal(20, retorno);
        }

        [Fact]
        public void CalculaMedia_ListaIdadesMaiorQue18EMenores_RetornaMedia()
        {
            // Arrange
            MediaIdades mediaIdade = new();

            List<int> idades = new() { 13, 15, 18, 20, 22, 36 };

            // Act
            decimal retorno = mediaIdade.CalculaMedia(idades);

            // Assert
            Assert.Equal(24, retorno);
        }

        [Fact]
        public void CalculaMedia_ListaIdadesVazia_RetornaExcecao()
        {
            // Arrange
            MediaIdades mediaIdade = new();

            List<int> idades = new();

            // Act
            Action retorno = () => mediaIdade.CalculaMedia(idades);

            // Assert
            Assert.Throws<DivideByZeroException>(retorno);
        }

        [Fact]
        public void CalculaMedia_ListaIdadesMenorQue18_RetornaExcecao()
        {
            // Arrange
            MediaIdades mediaIdade = new();

            List<int> idades = new() { 13, 7, 11 };

            // Act
            Action retorno = () => mediaIdade.CalculaMedia(idades);

            // Assert
            Assert.Throws<DivideByZeroException>(retorno);
        }
    }
}
