using System;
using FluentAssertions;
using Shop.Domain.Customers;
using Xunit;

namespace Shop.Tests.Domain
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_ShouldInitializeCorrectly()
        {
            var customer = new Customer(
                userName: "Alice",
                email: "alice@test.com",
                passwordHash: "hashedpassword",
                role: UserRole.Customer,
                salt: "randomsalt"
            );

            customer.UserName.Should().Be("Alice");
            customer.Email.Should().Be("alice@test.com");
            customer.PasswordHash.Should().Be("hashedpassword");
            customer.Salt.Should().Be("randomsalt");
            customer.Role.Should().Be(UserRole.Customer);
            customer.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void Customer_ChangePassword_ShouldUpdatePasswordHash()
        {
            var customer = new Customer("Alice", "alice@test.com", "oldhash", UserRole.Customer, "salt");
            customer.ChangePassword("newhash");

            customer.PasswordHash.Should().Be("newhash");

            Action nullPassword = () => customer.ChangePassword(null);
            nullPassword.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Customer_ChangeEmail_ShouldUpdateEmail()
        {
            var customer = new Customer("Alice", "alice@test.com", "hash", UserRole.Customer, "salt");
            customer.ChangeEmail("bob@test.com");

            customer.Email.Should().Be("bob@test.com");

            Action emptyEmail = () => customer.ChangeEmail("");
            emptyEmail.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Customer_ChangeRole_ShouldUpdateRole()
        {
            var customer = new Customer("Alice", "alice@test.com", "hash", UserRole.Customer, "salt");
            customer.ChangeRole(UserRole.Admin);

            customer.Role.Should().Be(UserRole.Admin);
        }

        [Fact]
        public void Customer_InvalidInitialization_ShouldThrow()
        {
            Action nullUserName = () => new Customer(null, "email@test.com", "hash", UserRole.Customer, "salt");
            nullUserName.Should().Throw<ArgumentNullException>();

            Action nullEmail = () => new Customer("Alice", null, "hash", UserRole.Customer, "salt");
            nullEmail.Should().Throw<ArgumentNullException>();

            Action nullPassword = () => new Customer("Alice", "email@test.com", null, UserRole.Customer, "salt");
            nullPassword.Should().Throw<ArgumentNullException>();
        }
    }
}
