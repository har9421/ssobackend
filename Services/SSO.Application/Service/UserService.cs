using AutoMapper;
using SSO.Application.Abstractions.DataAbstractions;
using SSO.Application.ViewModel;
using SSO.Domain;

namespace SSO.Application.Service;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
    public async Task<string> Login(UserVM user)
    {
        var userDto = mapper.Map<User>(user);
        if (await unitOfWork.Users.Login(userDto))
            return "Token";

        return "Login Failed";
    }

    public async Task RegisterUser(UserVM user)
    {
        await unitOfWork.StartTransactionAsync();
        try
        {
            var userDto = mapper.Map<UserVM, User>(user);
            await unitOfWork.Users.Register(userDto);
        }
        catch
        {
            await unitOfWork.RevertTransactionAsync();
            throw;
        }
    }
}
