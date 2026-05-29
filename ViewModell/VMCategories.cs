using ShopContent.Context;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShopContent.ViewModell
{
    public class VMCategories : INotifyPropertyChanged
    {
        private ObservableCollection<CategoryContext> _categories;

        public ObservableCollection<CategoryContext> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public ICommand NewCategory { get; set; }

        public VMCategories()
        {
            Categories = CategoryContext.AllCategories();
            NewCategory = new RelayCommand(obj =>
            {
                CategoryContext newCategory = new CategoryContext(true);
                MainWindow.Instance.OpenPage(new View.AddCategory(newCategory));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}