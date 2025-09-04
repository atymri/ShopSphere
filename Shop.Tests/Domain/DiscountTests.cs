using System;
using Xunit;
using FluentAssertions;
using Shop.Domain.Discounts;

namespace Shop.Tests.Domain
{
    public class DiscountTests
    {
        private readonly Guid productId = Guid.NewGuid();

        [Fact]
        public void Discount_ShouldInitializeCorrectly()
        {
            var start = DateTime.UtcNow.AddDays(-1);
            var end = DateTime.UtcNow.AddDays(1);
            var discount = new Discount(productId, 10, start, end);

            discount.Percentage.Should().Be(10);
            discount.ProductId.Should().Be(productId);
            discount.IsActive(DateTime.UtcNow).Should().BeTrue();
        }

        [Fact]
        public void Discount_InvalidPercentageOrDates_ShouldThrow()
        {
            var start = DateTime.UtcNow;
            var end = DateTime.UtcNow.AddDays(1);

            Action invalidPercentage = () => new Discount(productId, 150, start, end);
            invalidPercentage.Should().Throw<ArgumentOutOfRangeException>();

            Action invalidDates = () => new Discount(productId, 10, end, start);
            invalidDates.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Discount_IsActive_ShouldReturnFalseForInactive()
        {
            var start = DateTime.UtcNow.AddDays(-5);
            var end = DateTime.UtcNow.AddDays(-1);
            var discount = new Discount(productId, 10, start, end);
            discount.IsActive(DateTime.UtcNow).Should().BeFalse();
        }
    }
}
