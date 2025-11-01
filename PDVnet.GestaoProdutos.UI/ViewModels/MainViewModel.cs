using PDVnet.GestaoProdutos.Business;
using PDVnet.GestaoProdutos.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace PDVnet.GestaoProdutos.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ProdutoService _produtoService;
        private readonly RelatorioService _relatorioService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int TotalProdutos { get; set; }
        public int ProdutosBaixoEstoque { get; set; }
        public decimal ValorTotalEstoque { get; set; }
        public ObservableCollection<Produto> Produtos { get; set; }
        public Produto? ProdutoSelecionado { get; set; }     

        public MainViewModel()
        {
            _produtoService = new ProdutoService();
            _relatorioService = new RelatorioService();
            Produtos = new ObservableCollection<Produto>();     
            CarregarDados();

        }

        private void CarregarDados()
        {
            var listagem = _produtoService.ListarProdutos();
            Produtos.Clear();
            foreach (var produto in listagem)
                Produtos.Add(produto);

            TotalProdutos = _relatorioService.TotalProdutosEstoque();
            ProdutosBaixoEstoque = _relatorioService.ProdutosEstoqueBaixo().Count;
            ValorTotalEstoque = _relatorioService.ValorTotalEstoque();

        }

        public void AtualizarDados()
        { 
            CarregarDados();

            OnPropertyChanged(nameof(TotalProdutos));
            OnPropertyChanged(nameof(ProdutosBaixoEstoque));
            OnPropertyChanged(nameof(ValorTotalEstoque));
            OnPropertyChanged(nameof(Produtos));
        }

        private void OnPropertyChanged(string propriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }

        public void NovoProduto()
        {
            var produtoform = new Views.ProdutoForm();
            produtoform.ShowDialog();
            CarregarDados();
        }

        public void EditarProduto()
        {
            if (ProdutoSelecionado == null) return;

            var form = new Views.ProdutoForm()
            {
                DataContext = new ProdutoFormViewModel(ProdutoSelecionado)
            };

            form.ShowDialog();
            CarregarDados();
        }

        public void ExcluirProduto()
        { 
            if (ProdutoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto para excluir.", "Atenção",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var resultado = MessageBox.Show($"Deseja realmente excluir o produto '{ProdutoSelecionado.Nome}'?", "Confirmação",
                                                                                   MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (resultado == MessageBoxResult.Yes)
            {
                _produtoService.DeletarProduto(ProdutoSelecionado.Id);
                    MessageBox.Show("Produto excluído com sucesso!","Confirmação",MessageBoxButton.OK,MessageBoxImage.Information);

                CarregarDados();
            }
                        
        }

   


    }


}
