using System;

namespace Shop.Domain.Inventory
{
    public class InventoryItem
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public InventoryItem(Guid productId, int quantity)
        {
            if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            ProductId = productId;
            Quantity = quantity;
        }

        public void AddStock(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            Quantity += amount;
        }

        public void RemoveStock(int amount)
        {
            if (amount < 0 || amount > Quantity)
                throw new InvalidOperationException("Cannot remove more stock than available");
            Quantity -= amount;
        }
    }
}
