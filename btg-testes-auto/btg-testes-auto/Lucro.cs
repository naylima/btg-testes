namespace btg_testes_auto
{
    public class Lucro
    {
        // teste unitario alunas
        public decimal Calcular(decimal valorProduto)
        {
            //Um comerciante comprou um produto e
            //quer vende-lo com um lucro de 45 % se o valor da compra for menor que R$20,00;
            //caso contrário, o lucro será de 30 %.Entrar como valor do produto e imprimir o valor da venda.

            decimal percentualVenda = valorProduto < 20 ? 1.45M : 1.30M;

            return valorProduto * percentualVenda;

        }
    }
}
