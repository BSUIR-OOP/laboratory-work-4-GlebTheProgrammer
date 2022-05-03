using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Interfaces
{
    internal interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }
}
