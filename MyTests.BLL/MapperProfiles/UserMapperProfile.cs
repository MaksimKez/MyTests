using AutoMapper;
using MyTests.BLL.Models;
using MyTests.DAL.Entities;

namespace MyTests.BLL.MapperProfiles;

public class UserMapperProfile : Profile
{
    public UserMapperProfile() => CreateMap<UserEntity, User>().ReverseMap();
}