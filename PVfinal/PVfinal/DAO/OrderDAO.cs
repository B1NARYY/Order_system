using PVfinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PVfinal.DAO
{
    public class OrderDAO
    {
        public static List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();

            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT * FROM Orders";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OrderModel order = new OrderModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        OrderDate = Convert.ToDateTime(reader["order_date"]),
                        UserId = Convert.ToInt32(reader["user_id"])
                    };
                    orders.Add(order);
                }

                reader.Close();
            }

            return orders;
        }

        public static OrderModel GetOrder(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT * FROM Orders WHERE id = @orderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new OrderModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        OrderDate = Convert.ToDateTime(reader["order_date"]),
                        UserId = Convert.ToInt32(reader["user_id"])
                    };
                }

                reader.Close();
            }

            return null;
        }

        public static List<OrderModel> GetOrdersByUserId(int userId)
        {
            List<OrderModel> orders = new List<OrderModel>();

            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT * FROM Orders WHERE user_id = @userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OrderModel order = new OrderModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        OrderDate = Convert.ToDateTime(reader["order_date"]),
                        UserId = Convert.ToInt32(reader["user_id"])
                    };
                    orders.Add(order);
                }

                reader.Close();
            }

            return orders;
        }

        public static void AddOrder(OrderModel order)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "INSERT INTO Orders (order_date, user_id) VALUES (@orderDate, @userId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@userId", order.UserId);
                cmd.ExecuteNonQuery();

                // Získání ID nové objednávky
                cmd.CommandText = "SELECT @@IDENTITY";
                int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                // Přidání položek objednávky
                foreach (var item in order.OrderItems)
                {
                    item.OrderId = orderId;
                    OrderItemDAO.AddOrderItem(item);
                }
            }
        }

        public static void UpdateOrder(OrderModel order)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "UPDATE Orders SET order_date = @orderDate, user_id = @userId WHERE id = @orderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", order.Id);
                cmd.Parameters.AddWithValue("@orderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@userId", order.UserId);
                cmd.ExecuteNonQuery();

                // Aktualizace položek objednávky
                foreach (var item in order.OrderItems)
                {
                    OrderItemDAO.UpdateOrderItem(item);
                }
            }
        }

        public static void DeleteOrder(int orderId)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                // Smazání položek objednávky
                OrderItemDAO.DeleteOrderItemsByOrderId(orderId);

                // Smazání objednávky
                string query = "DELETE FROM Orders WHERE id = @orderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
