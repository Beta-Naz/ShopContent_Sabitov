using ShopContent.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShopContent
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public View.Main Main = new View.Main();

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            frame.Navigate(Main);
        }

        private void OpenIndex(object sendrt, MouseButtonEventArgs e)
        {
            frame.Navigate(Main);
        }
        private void OpenItems(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Main());
        }
        private void OpenCategories(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new MainCategory());
        }

        public void OpenPage(Page page)
        {
            frame.Navigate(page);
        }
    }
}