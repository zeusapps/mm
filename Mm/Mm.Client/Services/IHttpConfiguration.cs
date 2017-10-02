using System;

namespace Mm.Client.Services
{
    public interface IHttpConfiguration
    {
        Uri BaseUri { get; }
    }
}