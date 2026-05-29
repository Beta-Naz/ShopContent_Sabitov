using ShopContent.Context;
using System.Windows.Controls;

namespace ShopContent.View
{
    public partial class AddCategory : Page
    {
        public AddCategory(CategoryContext context)
        {
            InitializeComponent();
            DataContext = new { category = context };
        }
    }
}