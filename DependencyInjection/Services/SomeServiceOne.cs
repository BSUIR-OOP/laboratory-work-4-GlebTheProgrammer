using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    internal class SomeServiceOne : ISomeService
    {
        private readonly IRandomGuidProvider randomGuidProvider;

        public SomeServiceOne(IRandomGuidProvider randomGuidProvider)
        {
            this.randomGuidProvider = randomGuidProvider;
        }

        public void PrintSomething()
        {
            Console.WriteLine(randomGuidProvider.RandomGuid);
        }
    }
}
