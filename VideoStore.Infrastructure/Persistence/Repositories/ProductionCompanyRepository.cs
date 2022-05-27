using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Infrastructure.Persistence.Repositories
{
    public class ProductionCompanyRepository : IProductionCompanyRepository
    {
        private readonly VideoStoreDbContext _dbContext;

        public ProductionCompanyRepository(VideoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddProductionCompanyAsync(ProductionCompany productionCompany)
        {
            await _dbContext.ProductionCompanies.AddAsync(productionCompany);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<ProductionCompany>> GetAllAsync()
        {
            return await _dbContext.ProductionCompanies.ToListAsync();
        }

        public async Task<ProductionCompany> GetByIdAsync(int id)
        {
            return await _dbContext.ProductionCompanies.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
