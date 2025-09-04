using System;
using System.Collections.Generic;
using FluentAssertions;
using Shop.Domain.Orders;
using Xunit;

namespace Shop.Tests.Domain
{
    public class OrderTests
    {
        private readonly Guid productId = Guid.NewGuid();
        private readonly Guid customerId = Guid.NewGuid();

        [Fact]
        public void Order_ShouldInitializeCorrectly()
        {
            var order = new Order(customerId);
            order.Items.Should().BeEmpty();
            order.Status.Should().Be(OrderStatus.Pending);
            order.CustomerId.Should().Be(customerId);
        }

        [Fact]
        public void Order_AddAndRemoveItem_ShouldWork()
        {
            var order = new Order(customerId);
            var item = new OrderItem(productId, 100m, 2);
            order.AddItem(item);
            order.Items.Should().Contain(item);

            order.RemoveItem(item.Id);
            order.Items.Should().BeEmpty();
        }

        [Fact]
        public void Order_RemoveItem_NotExist_ShouldThrow()
        {
            var order = new Order(customerId);
            Action act = () => order.RemoveItem(Guid.NewGuid());
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Order_UpdateStatus_ShouldWork()
        {
            var order = new Order(customerId);
            order.UpdateStatus(OrderStatus.Shipped);
            order.Status.Should().Be(OrderStatus.Shipped);
        }

        [Fact]
        public void Order_TotalPrice_ShouldSumItems()
        {
            var order = new Order(customerId);
            order.AddItem(new OrderItem(productId, 100m, 2));
            order.AddItem(new OrderItem(productId, 50m, 1));
            order.TotalPrice.Should().Be(250m);
        }
    }
}
