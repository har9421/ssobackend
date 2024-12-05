using System;

namespace SSO.Application.Abstractions.DataAbstractions;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    Task StartTransactionAsync();
    Task SubmitTransactionAsync();
    Task RevertTransactionAsync();
}
