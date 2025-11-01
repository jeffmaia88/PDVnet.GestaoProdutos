using PDVnet.GestaoProdutos.Data;
using PDVnet.GestaoProdutos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVnet.GestaoProdutos.Business
{
    public class RelatorioService
    {
        private readonly ProdutoRepository _repository;

        public RelatorioService()
        {
            _repository = new ProdutoRepository();
        }

        public int TotalProdutosEstoque()
        {
            var total = _repository.ListarTodos();
            return total.Count();

        }

        public List<Produto> ProdutosEstoqueBaixo()
        {
            var baixoEstoque = _repository.ListarTodos().Where(p => p.Quantidade < 5).ToList();
            return baixoEstoque;

        }

        public decimal ValorTotalEstoque()
        { 
            var valor = _repository.ListarTodos();
            return valor.Sum(p => p.Preco * p.Quantidade);

        }

    }
}
