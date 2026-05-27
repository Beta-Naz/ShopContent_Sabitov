using System.Windows.Controls;

namespace ShopContent.View
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            DataContext = new ViewModell.VMItems();
        }
    }
}
