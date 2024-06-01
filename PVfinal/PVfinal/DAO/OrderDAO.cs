using PVfinal.DAO;
using PVfinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PVfinal.DAOs
{
    public class OrderDAO
    {
        // Method to get all orders
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

        // Method to add an order
        public void AddOrder(OrderModel order)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "INSERT INTO Orders (order_date, user_id) VALUES (@orderDate, @userId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@userId", order.UserId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Order added successfully");
        }

        // Method to update an order
        public void UpdateOrder(OrderModel order)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "UPDATE Orders SET order_date = @orderDate, user_id = @userId WHERE id = @orderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", order.Id);
                cmd.Parameters.AddWithValue("@orderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@userId", order.UserId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Order updated successfully");
        }

        // Method to delete an order
        public void DeleteOrder(int orderId)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "DELETE FROM Orders WHERE id = @orderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Order deleted successfully");
        }
    }
}
