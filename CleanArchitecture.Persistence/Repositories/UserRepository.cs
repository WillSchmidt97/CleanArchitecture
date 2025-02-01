using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext _context) : base(_context) {}
    
    public async Task<User> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
    }
}