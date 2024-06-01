using PVfinal.DAO;
using PVfinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PVfinal.DAOs
{
    public class OrderItemDAO
    {
        // Method to get all order items for a specific order
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

        // Method to add an order item
        public void AddOrderItem(OrderItemModel item)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "INSERT INTO OrderItems (order_id, item_id, quantity) VALUES (@orderId, @itemId, @quantity)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters
