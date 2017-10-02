using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mm.Client.Infrastructure
{
    public interface IInitializable
    {
        Task Initialize();
    }
}
