using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Domain.Orders
{
    public enum OrderStatus
    {
        Pending,
        Paid,
        Shipped,
        Delivered,
        Canceled
    }

    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public decimal TotalPrice => Items.Sum(i => i.TotalPrice);

        public Order(Guid customerId)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Items = new List<OrderItem>();
            Status = OrderStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Items.Add(item);
        }

        public void RemoveItem(Guid orderItemId)
        {
            var item = Items.FirstOrDefault(i => i.Id == orderItemId);
            if (item == null) throw new InvalidOperationException("Item not found in order");
            Items.Remove(item);
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
