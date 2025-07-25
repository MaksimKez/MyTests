using AutoMapper;
using MyTests.BLL.Models;
using MyTests.DAL.Entities;

namespace MyTests.BLL.MapperProfiles;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile() => CreateMap<ProductEntity, Product>().ReverseMap();
}