using System;

namespace Shop.Domain.Customers
{
    public class Address
    {
        public Guid Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }

        public Address(string street, string city, string postalCode, string country)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
            if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentNullException(nameof(postalCode));
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));

            Id = Guid.NewGuid();
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
