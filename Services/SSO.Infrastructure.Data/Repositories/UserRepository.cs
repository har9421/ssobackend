using Microsoft.EntityFrameworkCore;
using SSO.Application.Abstractions.DataAbstractions;
using SSO.Domain;

namespace SSO.Infrastructure.Data.Repositories;

public class UserRepository(SSODbContext context) : IUserRepository
{
    public async Task<bool> Login(User user)
    {
        return await context.Identities.AnyAsync(x => x.Username == user.Username && x.Password == user.Password);
    }

    public async Task Register(User user)
    {
        await context.Identities.AddAsync(user);
        await context.SaveChangesAsync();
    }
}
