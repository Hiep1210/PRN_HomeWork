using System;
using System.Collections.Generic;

namespace WPF_database.Models
{
    public partial class Order : IEquatable<Order>
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public bool Equals(Order order)
        {
            if (order is null)
                return false;
            return
                   OrderId == order.OrderId;
        }

        public override bool Equals(object? obj) => Equals(obj as Order);

        public override int GetHashCode() => (OrderId).GetHashCode();   
    }
}
