using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ShopContent.Context;

namespace ShopContent.ViewModell
{
    public class VMCategories : INotifyPropertyChanged
    {
        public ObservableCollection<CategoryContext> Categories { get; set; }
        public VMCategories() =>
            Categories = CategoryContext.AllCategories();

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
