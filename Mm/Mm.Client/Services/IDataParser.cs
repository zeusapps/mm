namespace Mm.Client.Services
{
    public interface IDataParser
    {
        T Deserialize<T>(string data);

        string Serialize(object obj);
    }
}
