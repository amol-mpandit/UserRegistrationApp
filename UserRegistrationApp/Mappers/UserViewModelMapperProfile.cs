using AutoMapper;
using Core;
using UserRegistrationApp.Models;

namespace UserRegistrationApp.Mappers
{
    public class UserViewModelMapperProfile : Profile
    {
        public UserViewModelMapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}