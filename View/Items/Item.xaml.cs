using System.Windows.Controls;
using ShopContent.Context;

namespace ShopContent.View.Items
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item(Enums.Type type = Enums.Type.Item)
        {
            InitializeComponent();
            if(type == Enums.Type.Item)
            {
                DataContext = new ItemContext();
            }
            else
            {
                DataContext = new CategoryContext();
            } 
        }
    }
}
