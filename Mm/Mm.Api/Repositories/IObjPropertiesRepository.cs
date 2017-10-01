using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mm.Api.Models;

namespace Mm.Api.Repositories
{
    public interface IObjPropertiesRepository
    {
        Task Create(ObjProperties properties);
        Task Delete(ObjProperties properties);
        Task<List<ObjProperties>> GetAll();
        Task<ObjProperties> GetById(Guid id);
        Task Update(ObjProperties properties);
        Task<bool> Contains(Guid id);
    }
}