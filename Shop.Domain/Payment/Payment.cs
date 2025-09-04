using System;

namespace Shop.Domain.Payments
{
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }

    public class Payment
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid PaymentMethodId { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime PaidAt { get; private set; }

        public Payment(Guid orderId, Guid paymentMethodId, decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));

            Id = Guid.NewGuid();
            OrderId = orderId;
            PaymentMethodId = paymentMethodId;
            Amount = amount;
            Status = PaymentStatus.Pending;
        }

        public void CompletePayment()
        {
            Status = PaymentStatus.Completed;
            PaidAt = DateTime.UtcNow;
        }

        public void FailPayment()
        {
            Status = PaymentStatus.Failed;
        }
    }
}
