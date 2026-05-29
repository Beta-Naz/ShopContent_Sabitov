using ShopContent.Context;
using System.Windows.Controls;

namespace ShopContent.View.Items
{
    public partial class ItemCategory : UserControl
    {
        public ItemCategory()
        {
            InitializeComponent();
        }
        public ItemCategory(CategoryContext category)
        {
            InitializeComponent();
            DataContext = category;
        }
    }
}