using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Application.Repositories
{
    public interface IProductionCompanyRepository
    {
        Task AddProductionCompanyAsync(ProductionCompany productionCompany);
        Task<ProductionCompany> GetByIdAsync(int id);
        Task<List<ProductionCompany>> GetAllAsync();
    }
}
