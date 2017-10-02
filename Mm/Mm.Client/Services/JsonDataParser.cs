using Newtonsoft.Json;

namespace Mm.Client.Services
{
    public class JsonDataParser : IDataParser
    {
        public T Deserialize<T>(string data) => JsonConvert.DeserializeObject<T>(data);

        public string Serialize(object obj) => JsonConvert.SerializeObject(obj);
    }
}
