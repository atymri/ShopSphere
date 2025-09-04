using System;
using FluentAssertions;
using Shop.Domain.Inventory;
using Xunit;

namespace Shop.Tests.Domain
{
    public class InventoryItemTests
    {
        [Fact]
        public void InventoryItem_ShouldInitializeCorrectly()
        {
            var item = new InventoryItem(Guid.NewGuid(), 50);
            item.Quantity.Should().Be(50);
        }

        [Fact]
        public void InventoryItem_AddAndRemoveStock_ShouldWork()
        {
            var item = new InventoryItem(Guid.NewGuid(), 10);
            item.AddStock(5);
            item.Quantity.Should().Be(15);

            item.RemoveStock(10);
            item.Quantity.Should().Be(5);

            Action removeTooMuch = () => item.RemoveStock(10);
            removeTooMuch.Should().Throw<InvalidOperationException>();
        }
    }
}
