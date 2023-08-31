using System;
using System.Security.Cryptography;
using System.Text;
using ToDoList.Enums;

namespace ToDoList.Entities
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public string? Email { get; set; }
        public string? Password { get; private set; }

        public ICollection<UserToDoList> UserToDoLists { get; set; } = new List<UserToDoList>();

        public void SetPassword(string password)
        {
            Password = HashPassword(password);
        }

        public bool ValidatePassword(string password)
        {
            return Password == HashPassword(password);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
