using System;
using FluentAssertions;
using Shop.Domain.Products;
using Xunit;

namespace Shop.Tests.Domain
{
    public class CategoryTests
    {
        [Fact]
        public void Category_ShouldInitializeCorrectly()
        {
            var category = new Category("Electronics");
            category.Name.Should().Be("Electronics");
            category.SubCategories.Should().BeEmpty();
            category.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void Category_Edit_ShouldChangeName()
        {
            var category = new Category("Electronics");
            category.Edit("Computers");
            category.Name.Should().Be("Computers");
        }

        [Fact]
        public void Category_AddSubCategory_ShouldWork()
        {
            var parent = new Category("Electronics");
            var sub = new Category("Laptops");
            parent.AddSubCategory(sub);
            parent.SubCategories.Should().Contain(sub);
        }
    }
}
