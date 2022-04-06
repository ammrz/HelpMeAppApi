using AutoMapper;
using HelpMeApp.Application.Dtos;
using HelpMeApp.Domain.Entities;
using System;

namespace HelpMeApp.Application.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ModelMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;

    }

    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<Request, RequestDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<HelpMeApp.Domain.Entities.Domain, DomainDto>().ReverseMap();
        }
    }
}
