using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using ShopContent.Classes;
using ShopContent.Model;
using ShopContent.ViewModell;

namespace ShopContent.Context
{
    public class CategoryContext : Category
    {
        public Visibility Visible = Visibility.Collapsed;

        public CategoryContext(bool save = false)
        {
            if (save) Save(true);
        }

        public static ObservableCollection<CategoryContext> AllCategories()
        {
            ObservableCollection<CategoryContext> allCategories = new ObservableCollection<CategoryContext>();
            SqlConnection connection = Connection.CreateConnection();
            string sql = "SELECT * FROM [dbo].[Categories]";
            SqlDataReader dataReader = Connection.Query(sql, connection);
            while (dataReader.Read())
            {
                allCategories.Add(new CategoryContext()
                {
                    Id = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                });
            }
            Connection.CloseConnection(connection);
            return allCategories;
        }

        public void Save(bool save = false)
        {
            SqlConnection connection = Connection.CreateConnection();
            if (save)
            {
                string sql = $"INSERT INTO " +
                    $"[dbo].[Categories]" +
                    $"(Name) " +
                    $"OUTPUT Inserted.Id " +
                    $"VALUES (N'{this.Name}');";
                SqlDataReader dataReader = Connection.Query(sql, connection);
                dataReader.Read();
                Id = dataReader.GetInt32(0);
            }
            else
            {
                string sql = $"UPDATE " +
                    $"[dbo].[Categories] " +
                    $"SET " +
                    $"Name = N'{this.Name}' " +
                    $"WHERE " +
                    $"Id = {this.Id};";
                Connection.Query(sql, connection);
            }
            Connection.CloseConnection(connection);
            MainWindow.Instance.OpenPage(MainWindow.Instance.Main);
        }

        public void Delete()
        {
            SqlConnection connection = Connection.CreateConnection();
            string sql = $"DELETE FROM [dbo].[Categories] " +
                $"WHERE " +
                $"Id = {this.Id}";
            Connection.Query(sql, connection);
        }

        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Save();
                });
            }
        }

        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.Instance.OpenPage(new View.AddCategory(this));
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
                    (MainWindow.Instance.Main.DataContext as ViewModell.VMCategories).Categories.Remove(this);
                });
            }
        }
    }
}