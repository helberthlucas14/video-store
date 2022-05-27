using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Application.Queries.GetAllProductionCompany
{
    public class GetAllProductionCompanyQuery : IRequest<List<ProductionCompany>>
    {
        
        public GetAllProductionCompanyQuery()
        {
        }

    }
}
