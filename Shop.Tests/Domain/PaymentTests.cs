using System;
using FluentAssertions;
using Shop.Domain.Payments;
using Xunit;

namespace Shop.Tests.Domain
{
    public class PaymentTests
    {
        [Fact]
        public void Payment_ShouldInitializeCorrectly()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), 100m);
            payment.Amount.Should().Be(100m);
            payment.Status.Should().Be(PaymentStatus.Pending);
        }

        [Fact]
        public void Payment_CompletePayment_ShouldUpdateStatus()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), 100m);
            payment.CompletePayment();
            payment.Status.Should().Be(PaymentStatus.Completed);
            payment.PaidAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void Payment_FailPayment_ShouldUpdateStatus()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), 100m);
            payment.FailPayment();
            payment.Status.Should().Be(PaymentStatus.Failed);
        }
    }
}
