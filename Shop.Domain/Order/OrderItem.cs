using System;

namespace Shop.Domain.Orders
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        public OrderItem(Guid productId, decimal unitPrice, int quantity)
        {
            if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            Id = Guid.NewGuid();
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public void ChangeQuantity(int newQuantity)
        {
            if (newQuantity <= 0) throw new ArgumentOutOfRangeException(nameof(newQuantity));
            Quantity = newQuantity;
        }
    }
}
