using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mm.Api.Models;

namespace Mm.Api.Repositories
{
    public class ObjPropertiesRepository : IObjPropertiesRepository
    {
        private readonly mmContext _context;

        public ObjPropertiesRepository(mmContext context)
        {
            _context = context;
        }

        public Task<List<ObjProperties>> GetAll()
        {
            return _context.ObjProperties.ToListAsync();
        }

        public Task<ObjProperties> GetById(Guid id)
        {
            return _context.ObjProperties.FindAsync(id);
        }

        public Task Create(ObjProperties properties)
        {
            _context.ObjProperties.Add(properties);
            return _context.SaveChangesAsync();
        }

        public Task Update(ObjProperties properties)
        {
            //_context.ObjProperties.Update(properties);
            return _context.SaveChangesAsync();
        }

        public async Task<bool> Contains(Guid id)
        {
            return (await _context.FindAsync<ObjProperties>(id)) != null;
        }

        public Task Delete(ObjProperties properties)
        {
            _context.ObjProperties.Remove(properties);
            return _context.SaveChangesAsync();
        }
    }
}
