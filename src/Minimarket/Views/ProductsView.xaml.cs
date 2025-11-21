using System.Windows;
using Minimarket.ViewModels;

namespace Minimarket.Views
{
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
            DataContext = new ProductsViewModel();
        }
    }
}