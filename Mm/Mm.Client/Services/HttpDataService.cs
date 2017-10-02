using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Mm.Core.DTOs;

namespace Mm.Client.Services
{
    public class HttpDataService : IDisposable, IDataService
    {
        private const string ROUTE = "/api/objproperties/";
        private readonly IDataParser _dataParser;
        private  readonly HttpClient _http;

        public HttpDataService(
            IHttpConfiguration configuration,
            IDataParser dataParser)
        {
            _dataParser = dataParser;
            _http = new HttpClient
            {
                BaseAddress = configuration.BaseUri
            };
        }

        public Task<List<ObjPropertiesDto>> GetAll() 
            => Get<List<ObjPropertiesDto>>(ROUTE);

        public Task<ObjPropertiesDto> GetById(string id)
            => Get<ObjPropertiesDto>(ROUTE + id);

        public async Task<ObjPropertiesDto> Update(string id, ObjPropertiesDto value)
        {
            var content = CreateContent(value);
            var response = await _http.PutAsync(new Uri(ROUTE + id, UriKind.Relative), content);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            return _dataParser.Deserialize<ObjPropertiesDto>(json);
        }

        public async Task<ObjPropertiesDto> Create(ObjPropertiesDto value)
        {
            value.PropertyId = Guid.NewGuid();
            var content = CreateContent(value);
            var response = await _http.PostAsync(new Uri(ROUTE, UriKind.Relative), content);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            return _dataParser.Deserialize<ObjPropertiesDto>(json);
        }

        public async Task<bool> Delete(string id)
        {
            var response = await _http.DeleteAsync(new Uri(ROUTE + id, UriKind.Relative));
            return response.IsSuccessStatusCode;
        }

        public void Dispose()
        {
            _http?.Dispose();
        }

        private HttpContent CreateContent(ObjPropertiesDto dto)
        {
            var json = _dataParser.Serialize(dto);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<T> Get<T>(string uri)
            where T : class
        {
            var response = await _http.GetAsync(new Uri(uri, UriKind.Relative));
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            return _dataParser.Deserialize<T>(json);
        }
    }
}
