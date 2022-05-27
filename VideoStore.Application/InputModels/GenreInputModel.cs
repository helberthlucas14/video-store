using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.InputModels
{
    public class GenreInputModel
    {
        public int Id { get; set; }

        public GenreInputModel(int id)
        {
            Id = id;
        }

    }
}
