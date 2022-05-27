using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using VideoStore.Application.Service.Auth;
using VideoStore.Core.Pagination;

namespace VideoStore.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VideoStoreDbContext _dbContext;
        private readonly IAuthService _authService;

        public UserRepository(VideoStoreDbContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }

        public async Task AddAsync(User user)
        {
            var passwordHash = _authService.ComputeSha256Hash(user.Password);
            var newUser = new User(user.Name, user.Email, passwordHash, user.Role);
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int Id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }

        public PagedList<User> GetAllAsync(UserParameters parameters)
        {
            var users = _dbContext.Users
                                        .OrderBy(p => p.Name)
                                        .IgnoreQueryFilters()
                                        .ToListAsync();

            return PagedList<User>.ToPagedList(users.Result, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email.Equals(email));
        }
    

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
