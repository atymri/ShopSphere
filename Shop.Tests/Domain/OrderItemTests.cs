using System;
using FluentAssertions;
using Shop.Domain.Orders;
using Xunit;

namespace Shop.Tests.Domain
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_ShouldInitializeCorrectly()
        {
            var item = new OrderItem(Guid.NewGuid(), 100m, 2);
            item.UnitPrice.Should().Be(100m);
            item.Quantity.Should().Be(2);
            item.TotalPrice.Should().Be(200m);
        }

        [Fact]
        public void OrderItem_ChangeQuantity_ShouldUpdateTotal()
        {
            var item = new OrderItem(Guid.NewGuid(), 50m, 3);
            item.ChangeQuantity(5);
            item.Quantity.Should().Be(5);
            item.TotalPrice.Should().Be(250m);

            Action negativeQty = () => item.ChangeQuantity(0);
            negativeQty.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
