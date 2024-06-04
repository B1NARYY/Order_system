using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PVfinal.Models;

namespace PVfinal.DAO
{
    public class ItemDAO
    {
        public static List<ItemModel> GetAllItems()
        {
            List<ItemModel> items = new List<ItemModel>();

            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT * FROM Items";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ItemModel item = new ItemModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        ItemName = reader["item_name"].ToString(),
                        Price = Convert.ToDecimal(reader["price"])
                    };
                    items.Add(item);
                }

                reader.Close();
            }

            return items;
        }

        public static ItemModel GetItem(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT * FROM Items WHERE id = @itemId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new ItemModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        ItemName = reader["item_name"].ToString(),
                        Price = Convert.ToDecimal(reader["price"])
                    };
                }

                reader.Close();
            }

            return null;
        }

        public static void AddItem(ItemModel item)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "INSERT INTO Items (item_name, price) VALUES (@itemName, @price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateItem(ItemModel item)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "UPDATE Items SET item_name = @itemName, price = @price WHERE id = @itemId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemId", item.Id);
                cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteItem(int itemId)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "DELETE FROM Items WHERE id = @itemId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemId", itemId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
