using System.Collections.ObjectModel;
using ShopContent.Model;

namespace ShopContent.Context
{
    public class ItemContext : Item
    {
        public ItemContext(bool save = false)
        {
            if (save) Save(true);
            Category = new Category();
        }
        public static ObservableCollection<ItemContext> AllItems()
        {
            ObservableCollection<ItemContext> allItems = new ObservableCollection<ItemContext>();
            ObservableCollection<CategoryContext> allCategories = CategoryContext.AllCategories();
        }
    }
}
