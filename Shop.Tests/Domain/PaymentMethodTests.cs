using System;
using FluentAssertions;
using Shop.Domain.Payments;
using Xunit;

namespace Shop.Tests.Domain
{
    public class PaymentMethodTests
    {
        [Fact]
        public void PaymentMethod_ShouldInitializeCorrectly()
        {
            var method = new PaymentMethod(Guid.NewGuid(), PaymentType.Card, "Visa **** 1234");
            method.Type.Should().Be(PaymentType.Card);
            method.Details.Should().Be("Visa **** 1234");
            method.Id.Should().NotBeEmpty();
        }
    }
}
