using PVfinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PVfinal.DAO
{
    public class OrderItemDAO
    {
        public static List<OrderItemModel> GetItemsInOrder(int orderId)
        {
            List<OrderItemModel> items = new List<OrderItemModel>();

            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT * FROM OrderItems WHERE order_id = @orderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OrderItemModel item = new OrderItemModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        OrderId = Convert.ToInt32(reader["order_id"]),
                        ItemId = Convert.ToInt32(reader["item_id"]),
                        Quantity = Convert.ToInt32(reader["quantity"])
                    };
                    items.Add(item);
                }

                reader.Close();
            }

            return items;
        }

        public static OrderItemModel GetOrderItem(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT * FROM OrderItems WHERE id = @orderItemId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderItemId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new OrderItemModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        OrderId = Convert.ToInt32(reader["order_id"]),
                        ItemId = Convert.ToInt32(reader["item_id"]),
                        Quantity = Convert.ToInt32(reader["quantity"])
                    };
                }

                reader.Close();
            }

            return null;
        }

        public static void AddOrderItem(OrderItemModel item)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "INSERT INTO OrderItems (order_id, item_id, quantity) VALUES (@orderId, @itemId, @quantity)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", item.OrderId);
                cmd.Parameters.AddWithValue("@itemId", item.ItemId);
                cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Order item added successfully");
        }

        public static void UpdateOrderItem(OrderItemModel item)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "UPDATE OrderItems SET order_id = @orderId, item_id = @itemId, quantity = @quantity WHERE id = @orderItemId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderItemId", item.Id);
                cmd.Parameters.AddWithValue("@orderId", item.OrderId);
                cmd.Parameters.AddWithValue("@itemId", item.ItemId);
                cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Order item updated successfully");
        }

        public static void DeleteOrderItem(int orderItemId)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "DELETE FROM OrderItems WHERE id = @orderItemId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderItemId", orderItemId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Order item deleted successfully");
        }

        public static void DeleteOrderItemsByOrderId(int orderId)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "DELETE FROM OrderItems WHERE order_id = @orderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Order items deleted successfully");
        }
    }
}
