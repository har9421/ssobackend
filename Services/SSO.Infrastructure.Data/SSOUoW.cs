using System;
using SSO.Application.Abstractions.DataAbstractions;

namespace SSO.Infrastructure.Data;

public class SSOUoW : IUnitOfWork
{
    private readonly SSODbContext _context;

    public SSOUoW(SSODbContext context, IUserRepository userRepository)
    {
        _context = context;
        Users = userRepository;
    }
    public IUserRepository Users { get; }

    public async Task StartTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }
    public async Task SubmitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RevertTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}

