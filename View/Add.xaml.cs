using System.Windows;
using System.Windows.Controls;
using ShopContent.Context;
using ShopContent.View.Items;
using ShopContent.ViewModell;

namespace ShopContent.View
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        
        public Add(object context)
        {
            InitializeComponent();
            DataContext = new
            {
                item = context,
                category = new VMCategories()
            };
        }
    }
}
