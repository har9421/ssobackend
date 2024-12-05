using System;
using SSO.Application.ViewModel;

namespace SSO.Application.Abstractions.DataAbstractions;

public interface IUserService
{
    Task<string> Login(UserVM user);
    Task RegisterUser(UserVM user);
}
