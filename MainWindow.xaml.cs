using System.Windows;
using System.Windows.Input;

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
    }
}
