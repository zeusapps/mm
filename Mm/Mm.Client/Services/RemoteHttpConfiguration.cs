using System;

namespace Mm.Client.Services
{
    public class RemoteHttpConfiguration : IHttpConfiguration
    {
        public Uri BaseUri => new Uri("http://45.115.243.56:8080");
    }
}
