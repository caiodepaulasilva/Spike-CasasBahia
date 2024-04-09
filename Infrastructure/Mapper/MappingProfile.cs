using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
    }
}
