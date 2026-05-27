using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ShopContent.Context;

namespace ShopContent.ViewModell
{
    public class VMItems : INotifyPropertyChanged
    {
        public ObservableCollection<ItemContext> Items { get; set; }
        public RelayCommand NewItem
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ItemContext newModell = new ItemContext(true);
                    Items.Add(newModell);
                    MainWindow.Instance.OpenPage(new View.Add(newModell));
                });
            }
        }
        public VMItems() =>
            Items = ItemContext.AllItems();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
