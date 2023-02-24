using AutoMapper;
using DbAccessLib.DTOs;
using DbAccessLib.Models;

namespace DbAccessLib.Configurations;

public class MapperConfig : Profile
{
	public MapperConfig()
	{
		CreateMap<TestModel, TestModelDto>().ReverseMap();
		CreateMap<TestModel, CreateTestModelDto>().ReverseMap();
	}
}