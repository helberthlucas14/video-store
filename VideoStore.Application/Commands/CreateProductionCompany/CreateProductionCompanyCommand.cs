using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Commands
{
    public class CreateProductionCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }

        public CreateProductionCompanyCommand(string name)
        {
            Name = name;
        }

    }
}
