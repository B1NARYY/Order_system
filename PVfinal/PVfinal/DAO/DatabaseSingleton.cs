using System;
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
                SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder
                {
                    UserID = "holy2",
                    Password = "holy2",
                    InitialCatalog = "holy2",
                    DataSource = "193.85.203.188",
                    ConnectTimeout = 30
                };

                conn = new SqlConnection(consStringBuilder.ConnectionString);
                try
                {
                    conn.Open(); 
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error opening connection: " + ex.Message);
                    conn = null; 
                }
            }
            return conn;
        }

        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null; 
            }
        }
    }
}
