using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; private set; }

        public Genre(string name)
        {
            Name = name;
        }

        public Genre(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
