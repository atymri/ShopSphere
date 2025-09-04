using System;

namespace Shop.Domain.Customers
{
    public enum UserRole
    {
        Customer,
        Admin,
        Seller
    }

    public class Customer
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; } // هش شده
        public string Salt { get; private set; }
        public UserRole Role { get; private set; }

        public Customer(string userName, string email, string passwordHash, UserRole role, string salt)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
            if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentNullException(nameof(passwordHash));

            Id = Guid.NewGuid();
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            Salt = salt;
        }

        public void ChangePassword(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash)) throw new ArgumentNullException(nameof(newPasswordHash));
            PasswordHash = newPasswordHash;
        }

        public void ChangeRole(UserRole newRole)
        {
            Role = newRole;
        }

        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail)) throw new ArgumentNullException(nameof(newEmail));
            Email = newEmail;
        }
    }
}
