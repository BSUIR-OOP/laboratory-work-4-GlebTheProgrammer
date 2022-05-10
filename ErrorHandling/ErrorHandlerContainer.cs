using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.ErrorHandling
{
    internal class ErrorHandlerContainer
    {
        private readonly string servicesNamespace;
        public ErrorHandlerContainer(string servicesNamespace)
        {
            this.servicesNamespace = servicesNamespace;
        }
        public string CheckForCycleDependency()
        {
            //Making a container for all used in DI Container Services
            var serviceDependenceContainer = new Dictionary<string, List<string>>();

            //Getting all the services types
            var services = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => String.Equals(t.Namespace, servicesNamespace, StringComparison.Ordinal))
                .ToArray();

            //Working with each Service
            foreach (var service in services)
            {
                //Getting main constructor from the Service
                var ctors = service.GetConstructors();
                var ctorMain = ctors[0];

                //Creating new List of Parameters Type used it that constructor
                List<string> parametersType = new List<string>();
 
                //Working with each Parameter
                foreach (var param in ctorMain.GetParameters())
                {
                    //Getting Parameter Name and writing it into the parametersType List
                    var parameterType = param.ParameterType.Name;
                    parametersType.Add(parameterType);
                }

                //Adding new service into serviceDependenceContainer for future cyclic dependencies checking
                serviceDependenceContainer.Add(nameof(service), parametersType);
            }

            var cycles = serviceDependenceContainer.FindCycles();

            if(cycles.Count != 0)
            {
                return "Cyclic Error";
            }
            else
                return string.Empty;


        }
    }
}
