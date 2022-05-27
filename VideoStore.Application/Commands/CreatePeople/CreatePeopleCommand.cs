using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Commands
{
    public class CreatePeopleCommand : IRequest<int>
    {
        public string Name { get;  set; }
        public string Biography { get;  set; }
        public string Gender { get;  set; }
        public DateTime Birthday { get;  set; }
        public DateTime CreatedAt { get;  set; }

        public CreatePeopleCommand(string name, string biography, string gender, DateTime birthday, DateTime createdAt)
        {
            Name = name;
            Biography = biography;
            Gender = gender;
            Birthday = birthday;
            CreatedAt = createdAt;
        }


    }
}
