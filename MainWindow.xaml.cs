using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ShopContent.Context;
using ShopContent.View;
using ShopContent.ViewModell;

namespace ShopContent
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public View.Main Main = new View.Main();
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }
        private void OpenIndex(object sendrt, MouseButtonEventArgs e)
        {
            frame.Navigate(Main);
        }
        public void OpenPage(Page page)
        {
            frame.Navigate(page);
        }
        public void ToggleContext(Page page, Enums.Type type = Enums.Type.Item, object context = null)
        {
            if (type == Enums.Type.Item)
            {
                if (page is Main)
                {
                    page.DataContext = new VMItems();
                }
                else if (page is Add && context != null)
                {
                    page.DataContext = new
                    {
                        item = context,
                        category = new VMCategories()
                    };
                }
            }
            else if (type == Enums.Type.Category)
            {
                if (page is Main)
                {
                    page.DataContext = new VMCategories();
                }
                else if (page is Add && context != null)
                {
                    page.DataContext = new CategoryContext();
                }
            }
        }
    }
}
