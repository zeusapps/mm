using System.Collections.Generic;
using System.Threading.Tasks;
using Mm.Core.DTOs;

namespace Mm.Client.Services
{
    public interface IDataService
    {
        Task<ObjPropertiesDto> Create(ObjPropertiesDto value);
        Task<bool> Delete(string id);
        void Dispose();
        Task<List<ObjPropertiesDto>> GetAll();
        Task<ObjPropertiesDto> GetById(string id);
        Task<ObjPropertiesDto> Update(string id, ObjPropertiesDto value);
    }
}