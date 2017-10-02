using System;
using AutoMapper;
using Mm.Api.Models;
using Mm.Core.DTOs;

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
