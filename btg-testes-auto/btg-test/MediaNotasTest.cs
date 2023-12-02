using btg_testes_auto;

namespace btg_test
{
    public class MediaNotasTest
    {
        [Fact]
        public void CalculaMedia_NotasSuperiorA7_RetornaAprovado()
        {
            // Arrange
            List<decimal> notas = new() { 7, 8, 9, 7 };
            MediaNotas mediaNotas = new();

            // Act
            string resultado = mediaNotas.CalculaMedia(notas, null);

            // Assert
            Assert.Contains("Parabéns, você foi aprovado!", resultado);
            Assert.Contains("7,75", resultado);
        }

        [Fact]
        public void CalculaMedia_NotasInferiorA7ComRecuperacaoOK_RetornaAprovado()
        {
            // Arrange
            List<decimal> notas = new() { 7, 5, 8, 7 };
            MediaNotas mediaNotas = new();
            decimal notaRecuperacao = 8;

            // Act
            string resultado = mediaNotas.CalculaMedia(notas, notaRecuperacao);

            // Assert
            Assert.Contains("Parabéns! Você foi aprovado na recuperação!", resultado);
            Assert.Contains("7,37", resultado);
        }

        [Fact]
        public void CalculaMedia_NotasInferiorA7ComRecuperacaoInsuficiente_RetornaAprovado()
        {
            // Arrange
            List<decimal> notas = new() { 7, 5, 8, 7 };
            MediaNotas mediaNotas = new();
            decimal notaRecuperacao = 5;

            // Act
            string resultado = mediaNotas.CalculaMedia(notas, notaRecuperacao);

            // Assert
            Assert.Equal("Infelizmente você não foi aprovado na recuperação :(. Sua média é: 5,875", resultado);
        }

        [Fact]
        public void CalculaMedia_NotasInferiorA7SemRecuperacao_RetornaAprovado()
        {
            // Arrange
            List<decimal> notas = new() { 7, 5, 8, 7 };
            MediaNotas mediaNotas = new();

            // Act
            string resultado = mediaNotas.CalculaMedia(notas, null);

            // Assert
            Assert.Equal("Infelizmente você não foi aprovado na recuperação :(. Sua média é: 6,75", resultado);
        }


    }
}
