using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ShopContent.Classes
{
    public class Connection
    {
        private readonly static string _connectionData =
            @"server=127.0.0.1;
              port=3306;
              database=shop;
              uid=root;
              pwd=";
        public static SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionData);
            connection.Open();
            return connection;
        }
        public static SqlDataReader Query(string sql, SqlConnection connection)
        {
            return new SqlCommand(sql, connection).ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
