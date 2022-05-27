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
    public class PeopleRepository : IPeopleRepository
    {
        private readonly VideoStoreDbContext _dbContext;

        public PeopleRepository(VideoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPeopleAsync(People people)
        {
            await _dbContext.Person.AddAsync(people);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<People>> GetAllAsync()
        {
            return await _dbContext.Person.ToListAsync();
        }

        public async Task<People> GetByIdAsync(int id)
        {
            return await _dbContext.Person.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
