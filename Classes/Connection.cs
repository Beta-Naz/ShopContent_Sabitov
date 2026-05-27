using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ShopContent.Classes
{
    public class Connection
    {
        private readonly static string _connectionData =
            @"server=10.0.201.112;
              database=base1_ISP_23_1_21;
              uid=ISP_23_1_21;
              pwd=D7x7gZZp-3_";
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
        public static void CloseConnection(SqlConnection connection)
        {
            connection.Close();
            SqlConnection.ClearPool(connection);
        }
    }
}
