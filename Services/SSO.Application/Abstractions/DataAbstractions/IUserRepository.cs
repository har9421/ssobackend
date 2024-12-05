using SSO.Domain;

namespace SSO.Application.Abstractions.DataAbstractions;

public interface IUserRepository
{
    Task<bool> Login(User user);
    Task Register(User user);
}
