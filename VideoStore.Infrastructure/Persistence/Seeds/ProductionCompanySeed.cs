using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Infrastructure.Persistence.Seeds
{
    public class ProductionCompanySeed
    {
        public static List<ProductionCompany> Seed()
        {
            var productionCompany = new List<ProductionCompany>()
            {
               new ProductionCompany(1,"Netflix"),
               new ProductionCompany(2,"Fox"),
               new ProductionCompany(3,"Paramount"),
               new ProductionCompany(4,"Pixar"),
               new ProductionCompany(5,"Marv Films"),
               new ProductionCompany(6,"Pinewood Studios"),
               new ProductionCompany(7,"Shepperton Studios"),
               new ProductionCompany(8,"Three Mills Studios"),
               new ProductionCompany(9,"606 Films"),
            };
            return productionCompany;
        }
    }
}
