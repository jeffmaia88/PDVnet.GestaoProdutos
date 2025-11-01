using Microsoft.Data.SqlClient;
using PDVnet.GestaoProdutos.Model;

namespace PDVnet.GestaoProdutos.Data
{
    public class ProdutoRepository
    {
        public List<Produto> ListarTodos()
        {
            var produtos = new List<Produto>();
            
            using (var connection = ConnectionHelper.GetConnection())
            {
               connection.Open();
               var command = new SqlCommand("SELECT Id, Nome, Descricao, Preco, Quantidade, DataCadastro FROM Produtos", connection);
               var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string descricao = "";

                    try
                    {
                        descricao = reader.GetString(2);
                    }
                    catch
                    {
                        descricao = "";
                    }

                    var produto = new Produto
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Descricao = descricao,
                        Preco = reader.GetDecimal(3),
                        Quantidade = reader.GetInt32(4),
                        DataCadastro = reader.GetDateTime(5)

                    };
                    produtos.Add(produto);                                          
                }
                return produtos;
            }
            
        }

        public void AdicionarProduto(Produto produto)
        {
            using (var connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(@"INSERT INTO Produtos (Nome, Descricao,Preco, Quantidade, DataCadastro)
                                            VALUES (@Nome, @Descricao, @Preco, @Quantidade, @DataCadastro)" , connection);

                command.Parameters.AddWithValue("@Nome", produto.Nome);
                if (produto.Descricao == null || produto.Descricao.Trim() == "")
                {
                    command.Parameters.AddWithValue("@Descricao", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                }

                command.Parameters.AddWithValue("@Preco", produto.Preco);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@DataCadastro", produto.DataCadastro);

                command.ExecuteNonQuery();
            }
        }

        public void AtualizarProduto(Produto produto)
        {
            using (var connection = ConnectionHelper.GetConnection())
            { 
               connection.Open();
                var command = new SqlCommand(@"UPDATE Produtos SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco,
                                                                        Quantidade = @Quantidade WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", produto.Id);
                command.Parameters.AddWithValue("@Nome", produto.Nome);
                if (produto.Descricao == null || produto.Descricao.Trim() == "")
                {
                    command.Parameters.AddWithValue("@Descricao", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                }
                command.Parameters.AddWithValue("@Preco", produto.Preco);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.ExecuteNonQuery();
            }                      
        }

        public void RemoverProduto(int produtoId)
        {
            using (var connection = ConnectionHelper.GetConnection())
            { 
                connection.Open();
                var command = new SqlCommand("DELETE FROM Produtos Where Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", produtoId);
                command.ExecuteNonQuery();
            }        
        }
    }
}
