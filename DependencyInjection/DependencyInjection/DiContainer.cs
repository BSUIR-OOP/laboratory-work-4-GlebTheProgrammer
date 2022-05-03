using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DependencyInjection
{
    internal class DiContainer
    {
        private List<ServiceDescriptor> serviceDescriptors;
        public DiContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            this.serviceDescriptors = serviceDescriptors;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                var service = serviceDescriptors
               .SingleOrDefault(x => x.ServiceType == serviceType);
            }
            catch (Exception)
            {
                throw new Exception("You can not access service because of 2 examplars in the container");
            }

            var descriptor = serviceDescriptors
               .SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
                throw new Exception($"Service of type {serviceType.Name} isn't registered");

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Cannot instantiate abstract classes or interfaces");
            }

            var constructorInfo = actualType.GetConstructors().First();

            //Handling nested dependencies is right here (using recursion)
            var parameters = constructorInfo.GetParameters()
                .Select(x => GetService(x.ParameterType)).ToArray();

            //Allow to create instance of a class dynamically just by using a type
            var implementation = Activator.CreateInstance(actualType, parameters);

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
                descriptor.Implementation = implementation;


            return implementation;

            //return default;
        }
        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}
