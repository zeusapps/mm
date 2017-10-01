using System.Collections;
using System.Collections.Generic;

namespace Mm.Api.Mapping
{
    public interface IMapperService
    {
        IEnumerable<TDest> Map<TDest>(IEnumerable sources);
        TDest Map<TDest>(object source);
        TDest Update<TDest>(object source, TDest dest);
    }
}