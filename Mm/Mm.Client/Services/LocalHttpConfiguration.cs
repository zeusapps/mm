using System;

namespace Mm.Client.Services
{
    class LocalHttpConfiguration : IHttpConfiguration
    {
        public Uri BaseUri => new Uri("http://localhost:49194");
    }
}
