using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public class People : BaseEntity
    {
        public string Name { get; private set; }
        public string Biography { get; private set; }
        public string Gender { get; private set; }
        public DateTime Birthday { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public People(string name, string biography, string gender, DateTime birthday)
        {
            Name = name;
            Biography = biography;
            Gender = gender;
            Birthday = birthday;
        }

        public People(int id, string name, string biography, string gender, DateTime birthday) : base(id)
        {
            Name = name;
            Biography = biography;
            Gender = gender;
            Birthday = birthday;
        }
    }
}
