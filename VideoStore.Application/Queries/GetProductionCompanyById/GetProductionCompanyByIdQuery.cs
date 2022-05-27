using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Application.Queries.GetProductionCompanyById
{
    public class GetProductionCompanyByIdQuery: IRequest<ProductionCompany>
    {
        public int Id { get; set; }

        public GetProductionCompanyByIdQuery(int id)
        {
            Id = id;
        }
    }
}
