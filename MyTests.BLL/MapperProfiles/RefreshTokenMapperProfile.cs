using AutoMapper;
using MyTests.BLL.Models;
using MyTests.BLL.Models.AuthRelated;
using MyTests.DAL.Entities;

namespace MyTests.BLL.MapperProfiles;

public class RefreshTokenMapperProfile : Profile    
{
    public RefreshTokenMapperProfile() => CreateMap<RefreshTokenEntity, RefreshToken>().ReverseMap();
}