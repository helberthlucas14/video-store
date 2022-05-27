using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public class MovieProductionCompany
    {
        public Movie Movie { get; private set; }
        public int MovieId { get; private set; }

        public ProductionCompany ProductionCompany { get; private set; }
        public int ProductionCompanyId { get; private set; }

        public MovieProductionCompany(int movieId, int productionCompanyId)
        {
            MovieId = movieId;
            ProductionCompanyId = productionCompanyId;
        }
    }
}
