using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DependencyInjection
{
    internal class DiServiceCollection
    {
        private List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor>();
        public void RegisterSingleton<TService>()
        {
            serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));
        }
        public void RegisterSingleton<TService, TImplementation>()
        {
            serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
        }
        public void RegisterSingleton<TService>(TService implementation)
        {
            serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
        }
        public void RegisterTransient<TService>()
        {
            serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
        }
        public void RegisterTransient<TService, TImplementation>()
        {
            serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }


        public DiContainer GenerateContainer()
        {
            return new DiContainer(serviceDescriptors);
        }
    }
}
