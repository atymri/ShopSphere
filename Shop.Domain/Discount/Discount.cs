using System;

namespace Shop.Domain.Discounts
{
    public class Discount
    {
        public Guid Id { get; private set; }
        public Guid? ProductId { get; private set; } // null = applies to all products
        public decimal Percentage { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Discount(Guid? productId, decimal percentage, DateTime startDate, DateTime endDate)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(percentage));
            if (startDate > endDate)
                throw new ArgumentException("StartDate cannot be after EndDate");

            Id = Guid.NewGuid();
            ProductId = productId;
            Percentage = percentage;
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool IsActive(DateTime date) => date >= StartDate && date <= EndDate;
    }
}
