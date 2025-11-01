using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using PDVnet.GestaoProdutos.UI.ViewModels;


namespace PDVnet.GestaoProdutos.UI.Views
{

    public partial class ProdutoForm : Window
    {
        public ProdutoForm()
        {
            InitializeComponent();
        }

        private void SalvarProdutoClick(object sender, RoutedEventArgs e)
        {
            var vm = (ProdutoFormViewModel)DataContext;
            vm.SalvarProduto();
        }

        private void CancelarClick(object sender, RoutedEventArgs e)
        {
            var vm = (ProdutoFormViewModel)DataContext;
            vm.Cancelar();
        }

        private void ValidarQuantidade(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void ValidarPreco(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9.,]+$");
        }

    }
}
