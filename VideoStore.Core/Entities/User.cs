using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public bool Active { get; private set; }
        public DateTime DeletedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public User(int id, string name, string email, string password, string role) : base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Active = true;
        }
        
        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Active = true;
        }

        public void UpdatePassword(string newPasswordHash)
        {
            Password = newPasswordHash;
        }

        public void SoftDelete()
        {
            Active = false;
            DeletedAt = DateTime.UtcNow;
        }
    }
}
