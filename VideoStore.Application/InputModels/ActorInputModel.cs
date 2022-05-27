using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.InputModels
{
    public class ActorInputModel
    {
        public int Id { get; set; }

        public ActorInputModel(int id)
        {
            Id = id;
        }
    }
}
