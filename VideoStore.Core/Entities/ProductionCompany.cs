using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public class ProductionCompany : BaseEntity
    {
        public string Name { get; private set; }

        public ProductionCompany(string name)
        {
            Name = name;
        }

        public ProductionCompany(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
