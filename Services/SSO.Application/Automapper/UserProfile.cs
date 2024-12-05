using AutoMapper;
using SSO.Application.ViewModel;
using SSO.Domain;

namespace SSO.Application.Automapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserVM, User>().ConstructUsing(x => new User(0, x.Username, x.Password, x.Domain));
        CreateMap<User, UserVM>().ConstructUsing(x => new UserVM(x.Username, x.Password, x.Domain));
    }

}
