using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.InputModels
{
    public class ProductionCompanyInputModel
    {
        public int Id { get; set; }

        public ProductionCompanyInputModel(int id)
        {
            Id = id;
        }
    }
}
