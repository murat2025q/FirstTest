using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Minimarket.Models;
using Minimarket.Data;
using Minimarket.Commands;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace Minimarket.ViewModels
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private readonly MinimarketDbContext _context;

        public ObservableCollection<Product> Products { get; set; } = new();

        private string? _newProductName;
        public string? NewProductName
        {
            get => _newProductName;
            set { _newProductName = value; OnPropertyChanged(); }
        }

        private string? _newProductPrice;
        public string? NewProductPrice
        {
            get => _newProductPrice;
            set { _newProductPrice = value; OnPropertyChanged(); }
        }

        private Product? _selectedProduct;
        public Product? SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand AddProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand UpdateProductCommand { get; }

        public ProductsViewModel(MinimarketDbContext context)
        {
            _context = context;
            AddProductCommand = new RelayCommand(_ => AddProduct());
            DeleteProductCommand = new RelayCommand(DeleteProduct, _ => SelectedProduct != null);
            UpdateProductCommand = new RelayCommand(UpdateProduct, _ => SelectedProduct != null);

            LoadProducts();
        }

        public void LoadProducts()
        {
            Products.Clear();
            foreach (var product in _context.Products.AsNoTracking().ToList())
                Products.Add(product);
        }

        private void AddProduct()
        {
            ErrorMessage = null;
            if (string.IsNullOrWhiteSpace(NewProductName))
            {
                ErrorMessage = "Ürün adı boş olamaz.";
                return;
            }
            if (NewProductName.Length > 100)
            {
                ErrorMessage = "Ürün adı 100 karakterden uzun olamaz.";
                return;
            }
            if (!decimal.TryParse(NewProductPrice, out var price) || price <= 0)
            {
                ErrorMessage = "Fiyat pozitif bir sayı olmalıdır.";
                return;
            }
            if (Products.Any(p => p.Name.ToLower() == NewProductName.ToLower()))
            {
                ErrorMessage = "Bu isimde bir ürün zaten mevcut.";
                return;
            }

            var product = new Product { Name = NewProductName, Price = price };
            _context.Products.Add(product);
            _context.SaveChanges();

            LoadProducts();
            NewProductName = string.Empty;
            NewProductPrice = string.Empty;
            ErrorMessage = null;
        }

        private void DeleteProduct(object? parameter)
        {
            ErrorMessage = null;
            if (parameter is Product prod)
            {
                var dbProd = _context.Products.Find(prod.Id);
                if (dbProd != null)
                {
                    _context.Products.Remove(dbProd);
                    _context.SaveChanges();
                    LoadProducts();
                }
                else
                {
                    ErrorMessage = "Silinecek ürün bulunamadı.";
                }
            }
        }

        private void UpdateProduct(object? parameter)
        {
            ErrorMessage = null;
            if (parameter is Product prod)
            {
                if (string.IsNullOrWhiteSpace(prod.Name))
                {
                    ErrorMessage = "Ürün adı boş olamaz.";
                    return;
                }
                if (prod.Name.Length > 100)
                {
                    ErrorMessage = "Ürün adı 100 karakterden uzun olamaz.";
                    return;
                }
                if (prod.Price <= 0)
                {
                    ErrorMessage = "Fiyat pozitif bir sayı olmalıdır.";
                    return;
                }
                var dbProd = _context.Products.Find(prod.Id);
                if (dbProd != null)
                {
                    dbProd.Name = prod.Name;
                    dbProd.Price = prod.Price;
                    _context.SaveChanges();
                    LoadProducts();
                }
                else
                {
                    ErrorMessage = "Güncellenecek ürün bulunamadı.";
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}