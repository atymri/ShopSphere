using System;
using FluentAssertions;
using Shop.Domain.Products;
using Xunit;

namespace Shop.Tests.Domain
{
    public class ProductTests
    {
        [Fact]
        public void Product_ShouldInitializeCorrectly()
        {
            var product = new Product("Laptop", "Gaming laptop", 1500m, 10);

            product.Title.Should().Be("Laptop");
            product.Description.Should().Be("Gaming laptop");
            product.Price.Should().Be(1500m);
            product.Stock.Should().Be(10);
            product.IsActive.Should().BeTrue();
            product.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void Product_Edit_ShouldUpdateProperties()
        {
            var product = new Product("Laptop", "Gaming laptop", 1500m, 10);
            product.Edit("Desktop", "Workstation desktop", 2000m, 5);

            product.Title.Should().Be("Desktop");
            product.Description.Should().Be("Workstation desktop");
            product.Price.Should().Be(2000m);
            product.Stock.Should().Be(5);
        }

        [Fact]
        public void Product_ChangeStock_ShouldWorkCorrectly()
        {
            var product = new Product("Laptop", "Desc", 1000m, 5);
            product.ChangeStock(3);
            product.Stock.Should().Be(8);

            Action removeTooMuch = () => product.ChangeStock(-10);
            removeTooMuch.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Product_ActivateDeactivate_ShouldWork()
        {
            var product = new Product("Laptop", "Desc", 1000m, 5);
            product.Deactivate();
            product.IsActive.Should().BeFalse();

            product.Activate();
            product.IsActive.Should().BeTrue();
        }
    }
}
