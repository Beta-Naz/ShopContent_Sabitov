using System.Windows.Controls;
using ShopContent.ViewModell;

namespace ShopContent.View
{
    public partial class MainCategory : Page
    {
        public MainCategory()
        {
            InitializeComponent();
            DataContext = new VMCategories();
        }
    }
}