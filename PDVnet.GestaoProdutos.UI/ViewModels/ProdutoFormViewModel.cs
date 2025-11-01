using PDVnet.GestaoProdutos.Business;
using PDVnet.GestaoProdutos.Model;
using System.Windows;

namespace PDVnet.GestaoProdutos.UI.ViewModels
{
    public class ProdutoFormViewModel
    {
        private readonly ProdutoService _produtoService;

        public Produto Produto { get; set; }

        public ProdutoFormViewModel()
        {
            _produtoService = new ProdutoService();
            Produto = new Produto();
        }

        public ProdutoFormViewModel(Produto produtoedit)
        { 
            _produtoService = new ProdutoService();
            Produto = produtoedit;

        }

        public void SalvarProduto()
        {
            try
            {
                _produtoService.CadastrarProduto(Produto);
                MessageBox.Show("Produto salvo com sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
                FecharJanela();
            }
            catch
            {
                MessageBox.Show("Erro ao salvar o produto. Verifique os dados e tente novamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        public void Cancelar()
        {
            FecharJanela();
        }

        private void FecharJanela()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }


    }
}
