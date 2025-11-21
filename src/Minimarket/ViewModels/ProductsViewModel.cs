using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Minimarket.ViewModels
{
    public class ProductsViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }

        public ProductsViewModel()
        {
            // Initialize commands and product list
        }
    }
}