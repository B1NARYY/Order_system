using PVfinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PVfinal.DAO
{
    public class ItemDAO
    {
        // Method to get all items
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

        // Method to add an item
        public void AddItem(ItemModel item)
        {
            using(SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "INSERT INTO Items (item_name, price) VALUES (@itemName, @price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Item added successfully");
        }

        // Method to update an item
        public void UpdateItem(ItemModel item)
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
            Console.WriteLine("Item updated successfully");
        }

        // Method to delete an item
        public void DeleteItem(int itemId)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "DELETE FROM Items WHERE id = @itemId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemId", itemId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Item deleted successfully");
        }
    }
}
