using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<int>
    {
        public string Name { get; set; }

        public CreateGenreCommand(string name)
        {
            Name = name;
        }
    }
}
