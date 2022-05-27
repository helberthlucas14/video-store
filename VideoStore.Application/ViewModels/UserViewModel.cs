using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Application.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime DeletedAt { get; private set; }

        public UserViewModel (User  user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Active = user.Active;
            CreatedAt = user.CreatedAt;
            DeletedAt = user.DeletedAt;
        }

    }
}
