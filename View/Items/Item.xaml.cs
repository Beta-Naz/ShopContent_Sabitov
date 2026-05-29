using System.Windows.Controls;
using ShopContent.Context;

namespace ShopContent.View.Items
{
    public partial class Item : UserControl
    {
        public Item(ItemContext itemContext)
        {
            InitializeComponent();
            DataContext = itemContext;
        }
        public Item()
        {
            InitializeComponent();
        }
    }
}