using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace Mm.Api.Mapping
{
    public class MapperService : IMapperService
    {
        public MapperService(IMapperConfiguration configuration)
        {
            Mapper.Initialize(configuration.Config());
        }


        public TDest Map<TDest>(object source)
        {
            return Mapper.Map<TDest>(source);
        }

        public TDest Update<TDest>(object source, TDest dest)
        {
            return Mapper.Map(source, dest);
        }

        public IEnumerable<TDest> Map<TDest>(IEnumerable sources)
        {
            foreach (var source in sources)
            {
                yield return Map<TDest>(source);
            }
        }
    }
}
