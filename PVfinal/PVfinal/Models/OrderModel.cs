using System;
using System.Collections.Generic;

namespace PVfinal.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public List<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();
    }
}
