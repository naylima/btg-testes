using btg_testes_auto;

namespace btg_test;

public class MeiaCinemaTest
{
    [Theory]
    [InlineData(true, false, false, false)] // Estudante
    [InlineData(false, true, false, false)] // Doador de sangue
    [InlineData(false, false, true, true)]  // Trabalhador da prefeitura com contrato tem direito
    [InlineData(false, true, true, true)] // Doador de sangue e trabalhador da prefeitura com contrato
    [InlineData(true, true, false, false)]  // Estudante e doador de sangue
    [InlineData(true, false, true, true)]   // Estudante e trabalhador da prefeitura com contrato
    public void VerificarMeiaCinema_PossuiDireitoMeia_RetornaTrue(
        bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
    {
        // Arrange
        MeiaCinema meiaCinema = new();

        // Act
        bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

        // Assert
        Assert.True(resultado);
    }

    [Theory]
    [InlineData(false, false, false, false)] // Nenhuma condição atendida
    [InlineData(false, false, true, false)]   // Trabalhador da prefeitura sem contrato
    [InlineData(false, false, false, true)]  // Apenas contrato com a prefeitura
    public void VerificarMeiaCinema_NaoPossuiDireitoMeia_RetornaFalse(
        bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
    {
        // Arrange
        MeiaCinema meiaCinema = new();

        // Act
        bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

        // Assert
        Assert.False(resultado);
    }
}
