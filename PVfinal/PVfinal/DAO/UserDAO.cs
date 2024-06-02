using PVfinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PVfinal.DAO
{
    public class UserDAO
    {
        public static List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserModel user = new UserModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Username = reader["username"].ToString(),
                        Balance = Convert.ToDecimal(reader["balance"])
                    };
                    users.Add(user);
                }

                reader.Close();
            }

            return users;
        }

        public static UserModel GetUser(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT * FROM Users WHERE id = @userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new UserModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Username = reader["username"].ToString(),
                        Balance = Convert.ToDecimal(reader["balance"])
                    };
                }

                reader.Close();
            }

            return null;
        }

        public static void AddUser(UserModel user)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "INSERT INTO Users (username, balance) VALUES (@username, @balance)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@balance", user.Balance);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("User added successfully");
        }

        public static void UpdateUser(UserModel user)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "UPDATE Users SET username = @username, balance = @balance WHERE id = @userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", user.Id);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@balance", user.Balance);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("User updated successfully");
        }

        public static void DeleteUser(int userId)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "DELETE FROM Users WHERE id = @userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("User deleted successfully");
        }
    }
}
