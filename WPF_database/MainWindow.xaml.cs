using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_database.Logic;
using WPF_database.Models;

namespace WPF_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProductServices productServices;
        private Categoryservice categoryService;
        public MainWindow()
        {
            InitializeComponent();
            productServices = new ProductServices();
            categoryService = new Categoryservice();
            cbCategories.ItemsSource = categoryService.GetCategories();
            cbCategories.SelectedIndex = 0;
        }

        private void ChangeEvent(object sender, SelectionChangedEventArgs e)
        {
            int CatId = ((Category)cbCategories.SelectedItem).CategoryId;
            lbProduct.ItemsSource = productServices.GetProducts(0);
        }
    }
}