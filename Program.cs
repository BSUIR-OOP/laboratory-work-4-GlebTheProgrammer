using DependencyInjection.DependencyInjection;
using DependencyInjection.ErrorHandling;
using DependencyInjection.Interfaces;
using DependencyInjection.Providers;
using DependencyInjection.Services;
using System.Reflection;

var services = new DiServiceCollection();


//Checking cyclic dependencies section strts here

var mockServiceDependence = new Dictionary<string, List<string>>
{
    { "A", new List<string> { "A" }},
    { "B", new List<string> { "C", "D" }},
    { "D", new List<string> { "E" }},
    { "E", new List<string> { "F", "Q" }},
    { "F", new List<string> { "D" }},
};
var mockCycles = mockServiceDependence.FindCycles();
if (mockCycles.Count != 0)
    throw new StackOverflowException("You have cyclic dependencies problems");

ErrorHandlerContainer errorHandlerContainer = new ErrorHandlerContainer("DependencyInjection.Services");
if (errorHandlerContainer.CheckForCycleDependency() != String.Empty)
    throw new StackOverflowException("You have cyclic dependencies problems");


//Checking cyclic dependencies section ends here


//Register services in DiServiceCollection Section Starts Here

services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();

services.RegisterSingleton<ISomeService, SomeServiceOne>();

//Register services in DiServiceCollection Section Ends Here

// Generate the container with our services
var container = services.GenerateContainer();

var serviceFirst = container.GetService<ISomeService>();
var serviceSecond = container.GetService<ISomeService>();

serviceFirst.PrintSomething();
serviceSecond.PrintSomething();
