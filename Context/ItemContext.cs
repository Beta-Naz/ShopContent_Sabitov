using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using ShopContent.Model;
using ShopContent.ViewModell;

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
            SqlConnection connection = Classes.Connection.CreateConnection();
            SqlDataReader dataItems = Classes.Connection.Query("SELECT * FROM [dbo].[Items]", connection);
            while (dataItems.Read())
            {
                allItems.Add(new ItemContext()
                {
                    Id = dataItems.GetInt32(0),
                    Name = dataItems.GetString(1),
                    Price = dataItems.GetDouble(2),
                    Description = dataItems.GetString(3),
                    Category = dataItems.IsDBNull(4) ? null : allCategories.Where(x => x.Id == dataItems.GetInt32(4)).First()
                });
            }
            Classes.Connection.CloseConnection(connection);
            return allItems;
        }
        public void Save(bool save = false)
        {
            SqlConnection connection = Classes.Connection.CreateConnection();
            if (save)
            {
                string sql = $"INSERT INTO " +
                    $"[dbo].[items]" +
                    $"(Name,Price,Description) " +
                    $"OUTPUT Inserted.Id " +
                    $"VALUES (N'{this.Name}', " +
                    $"{this.Price}, N'{this.Description}');";
                SqlDataReader dataReader = Classes.Connection.Query(sql, connection);
                dataReader.Read();
                Id = dataReader.GetInt32(0);
            }
            else
            {
                string sql = $"UPDATE " +
                    $"[dbo].[items] " +
                    $"SET " +
                    $"Name = N'{this.Name}', " +
                    $"Price = {this.Price}, " +
                    $"Description = N'{this.Description}', " +
                    $"IdCategory = {this.Category.Id} " +
                    $"WHERE " +
                    $"Id ={this.Id};";
                Classes.Connection.Query(sql, connection);
            }
            Classes.Connection.CloseConnection(connection);
            MainWindow.Instance.OpenPage(MainWindow.Instance.Main);
        }
        public void Delete()
        {
            SqlConnection connection = Classes.Connection.CreateConnection();
            string sql = $"DELETE FROM [dbo].[Items]" +
                $"WHERE " +
                $"Id = {this.Id}";
            Classes.Connection.Query(sql, connection);
        }
        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Category = CategoryContext.AllCategories().Where(x => x.Id == this.Category.Id).First();
                    Save();
                });            }
        }
        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.Instance.OpenPage(new View.Add(this));
                });
            }
        }
        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Delete();
                    (MainWindow.Instance.Main.DataContext as ViewModell.VMItems).Items.Remove(this);
                });
            }
        }
    }
}
