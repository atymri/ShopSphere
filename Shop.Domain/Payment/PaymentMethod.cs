using System;

namespace Shop.Domain.Payments
{
    public enum PaymentType
    {
        Card,
        PayPal,
        BankTransfer
    }

    public class PaymentMethod
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public PaymentType Type { get; private set; }
        public string Details { get; private set; }

        public PaymentMethod(Guid customerId, PaymentType type, string details)
        {
            if (string.IsNullOrWhiteSpace(details)) throw new ArgumentNullException(nameof(details));

            Id = Guid.NewGuid();
            CustomerId = customerId;
            Type = type;
            Details = details;
        }
    }
}
