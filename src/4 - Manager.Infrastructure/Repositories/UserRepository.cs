using Microsoft.EntityFrameworkCore;
using Manager.Infrastructure.Interfaces;
using Manager.Infrasctructure.Context;
using System.Threading.Tasks;
using Manager.Domain.Entities;
using System.Linq;
using System;

namespace Manager.Infrasctructure.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context): Base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = _context.Users
                               .Where
                               (
                                    x => 
                                        x.Email.ToLower() == email.ToLower()
                               )
                               .AsNotTracking()
                               .ToListAsync();

            return user.FirstOrDefault;
        }

        
        public Task<List<User>> SearchByEmail(string email)
        {
            var users = _context.Users
                               .Where
                               (
                                    x =>
                                        x.Email.ToLower().Contains(email.ToLower())
                               )
                               .AsNotTracking()
                               .ToListAsync()

            return users;
        }

        public Task<List<User>> SearchByName(string name)
        {
            var users = _context.Users
                               .Where
                               (
                                    x =>
                                        x.Name.ToLower().Contains(name.ToLower())
                               )
                               .AsNotTracking()
                               .ToListAsync()

            return users;
        }

    }
}