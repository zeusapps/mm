using System;
using AutoMapper;
using Mm.Api.DTOs;
using Mm.Api.Models;

namespace Mm.Api.Mapping
{
    public class MapperConfiguration : IMapperConfiguration
    {
        public Action<IMapperConfigurationExpression> Config()
        {
            return c =>
            {
                c.CreateMap<ObjProperties, ObjPropertiesDto>().ReverseMap();
            };
        }
    }
}
