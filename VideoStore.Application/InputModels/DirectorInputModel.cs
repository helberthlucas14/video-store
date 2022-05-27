using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.InputModels
{
    public class DirectorInputModel
    {
        public int Id { get; set; }

        public DirectorInputModel(int id)
        {
            Id = id;
        }
    }
}
