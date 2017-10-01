using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mm.Api.DTOs;
using Mm.Api.Mapping;
using Mm.Api.Models;
using Mm.Api.Repositories;

namespace Mm.Api.Controllers
{
    [Route("api/[controller]")]
    public class ObjPropertiesController : Controller
    {
        private readonly IObjPropertiesRepository _repository;
        private readonly IMapperService _mapperService;
        private readonly IUrlHelper _urlHelper;

        public ObjPropertiesController(
            IObjPropertiesRepository repository,
            IMapperService mapperService,
            IUrlHelper urlHelper)
        {
            _repository = repository;
            _mapperService = mapperService;
            _urlHelper = urlHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var properties = await _repository.GetAll();
            var dtos = _mapperService.Map<ObjPropertiesDto>(properties);
            return Ok(dtos);
        }

        private const string GET_OBJ_PROPERTIES_ROUTE = "get-objProperties-route";
        [HttpGet("{id}", Name = GET_OBJ_PROPERTIES_ROUTE)]
        public async Task<IActionResult> Get(Guid id)
        {
            var property = await _repository.GetById(id);
            if (property == null)
            {
                return NotFound();
            }

            var dto = _mapperService.Map<ObjPropertiesDto>(property);
            return Ok(dto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ObjPropertiesDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var property = _mapperService.Map<ObjProperties>(dto);
            await _repository.Create(property);


            var url = _urlHelper.RouteUrl(GET_OBJ_PROPERTIES_ROUTE, new {id = property.PropertyId});
            var created = _mapperService.Map<ObjPropertiesDto>(property);
            return Created(url, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ObjPropertiesDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var property = await _repository.GetById(dto.PropertyId);
            if (property == null)
            {
                return NotFound();
            }

            property = _mapperService.Update(dto, property);
            await _repository.Update(property);
            
            var url = _urlHelper.RouteUrl(GET_OBJ_PROPERTIES_ROUTE, new { id = property.PropertyId });
            var accepted = _mapperService.Map<ObjPropertiesDto>(property);

            return Accepted(new Uri(url, UriKind.Relative), accepted);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var property = await _repository.GetById(id);

            if (property == null)
            {
                return NotFound();
            }

            await _repository.Delete(property);
            return NoContent();
        }
    }
}
