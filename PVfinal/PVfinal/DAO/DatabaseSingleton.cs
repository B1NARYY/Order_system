using System.Data.SqlClient;

namespace PVfinal.DAO
{
    // Singleton class for database connection
    public class DatabaseSingleton
    {
        private static SqlConnection conn = null;
        private DatabaseSingleton()
        {
        }

        public static SqlConnection GetInstance()
        {
            if (conn == null)
            {
                SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();

                // Nastavení parametrů natvrdo
                consStringBuilder.UserID = "holy2";
                consStringBuilder.Password = "holy2";
                consStringBuilder.InitialCatalog = "holy2";
                consStringBuilder.DataSource = "193.85.203.188";
                consStringBuilder.ConnectTimeout = 30;

                conn = new SqlConnection(consStringBuilder.ConnectionString);
                conn.Open();
            }
            return conn;
        }

        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null; // Reset the connection to ensure it can be recreated later
            }
        }
    }
}
