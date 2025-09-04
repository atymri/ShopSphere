using System;
using FluentAssertions;
using Shop.Domain.Customers;
using Xunit;

namespace Shop.Tests.Domain
{
    public class AddressTests
    {
        [Fact]
        public void Address_ShouldInitializeCorrectly()
        {
            var address = new Address("Street 1", "City", "12345", "Country");
            address.Street.Should().Be("Street 1");
            address.City.Should().Be("City");
            address.PostalCode.Should().Be("12345");
            address.Country.Should().Be("Country");
            address.Id.Should().NotBeEmpty();
        }
    }
}
