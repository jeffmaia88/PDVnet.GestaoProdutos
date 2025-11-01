using PDVnet.GestaoProdutos.Model;


namespace PDVnet.GestaoProdutos.Business.Validators
{
    public static class ProdutoValidator
    {
      public static void ValidarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new Exception("O produto não pode ser nulo.");
            }

            if (produto.Nome == "" || produto.Nome.Trim() == "")
            {
                throw new Exception("O nome do produto não pode ser vazio.");
            }

            if (produto.Preco <= 0)
            {
                throw new Exception("O preço do produto não pode ser negativo.");
            }

            if (produto.Quantidade <= 0)
            {
                throw new Exception("A quantidade do produto não pode ser negativa.");
            }



        }
     

    }
}
