using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using ShopContent.Classes;
using ShopContent.Model;

namespace ShopContent.Context
{
    public class CategoryContext : Category
    {
        public Visibility Visible = Visibility.Collapsed;
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
        public double Price;
        public string Description;
        public int Category;
    }
}
