using PDVnet.GestaoProdutos.Business.Validators;
using PDVnet.GestaoProdutos.Data;
using PDVnet.GestaoProdutos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVnet.GestaoProdutos.Business
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _repository;

        public ProdutoService()
        {
            _repository = new ProdutoRepository();
        }

        public void CadastrarProduto(Produto produto)
        {
            if (produto.Id == 0)
            {
                ProdutoValidator.ValidarProduto(produto);
                produto.DataCadastro = DateTime.Now;
                _repository.AdicionarProduto(produto);
            }
            else
            {
                _repository.AtualizarProduto(produto);
            }
        }

        public List<Produto> ListarProdutos()
        { 
            return _repository.ListarTodos();
        }

        public void AtualizarProduto(Produto produto)
        {
            if (produto.Id <= 0)
            { 
                throw new Exception("O ID do produto é inválido.");
            }
            ProdutoValidator.ValidarProduto(produto);
            _repository.AtualizarProduto(produto);        
        }

        public void DeletarProduto(int produtoId)
        {
            if (produtoId <= 0)
            { 
                throw new Exception("O ID do produto é inválido.");
            }
            _repository.RemoverProduto(produtoId);
        }
    }
}
