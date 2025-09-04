using System;

namespace Shop.Domain.Products
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public bool IsActive { get; private set; }

        public Product(string title, string description, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
            if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock));

            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Price = price;
            Stock = stock;
            IsActive = true;
        }

        public void Edit(string title, string description, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
            if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock));

            Title = title;
            Description = description;
            Price = price;
            Stock = stock;
        }

        public void ChangeStock(int amount)
        {
            if (Stock + amount < 0) throw new InvalidOperationException("Stock cannot be negative");
            Stock += amount;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
