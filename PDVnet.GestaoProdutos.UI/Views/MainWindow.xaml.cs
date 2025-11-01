using System.Windows;
using PDVnet.GestaoProdutos.UI.ViewModels;

namespace PDVnet.GestaoProdutos.UI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NovoProdutoClick(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.NovoProduto();
        }

        private void EditarProdutoClick(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.EditarProduto();
        }

        private void ExcluirProdutoClick(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.ExcluirProduto();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.AtualizarDados();
        }

    }
}
