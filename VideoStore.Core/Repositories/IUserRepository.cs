using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Core.Pagination;

namespace VideoStore.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int Id);
        Task<User> GetUserByEmailAsync(string email);
        Task AddAsync(User user);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        PagedList<User> GetAllAsync(UserParameters parameters);
        Task SaveChangesAsync();
    }
}
