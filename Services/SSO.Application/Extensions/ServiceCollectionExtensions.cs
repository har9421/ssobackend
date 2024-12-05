using Microsoft.Extensions.DependencyInjection;
using SSO.Application.Abstractions.DataAbstractions;
using SSO.Application.Service;
using AutoMapper;

namespace SSO.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // services.AddMediatR(cfg =>
        // {
        //     cfg.RegisterServicesFromAssembly(typeof(IUserRepository).Assembly);
        // });
        //services.AddSingleton<IdentityService>();
        services.AddScoped<IUserService, UserService>();
        services.AddAutoMapper(typeof(ServiceCollectionExtensions));
        //services.AddScoped<CurrentAthlete>();
        return services;
    }

}
