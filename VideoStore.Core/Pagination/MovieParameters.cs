using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Core.Pagination
{
    public class MovieParameters : QueryStringParameters
    {
        public string GenreFilter { get; set; }
        public string ActorFilter { get; set; }
        public string DirectorFilter { get; set; }
        public string ProductionCompanyFilter { get; set; }
    }
}
