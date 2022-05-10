using DependencyInjection.DependencyInjection;
using DependencyInjection.Interfaces;
using DependencyInjection.Providers;
using DependencyInjection.Services;

var services = new DiServiceCollection();

//Register services in DiServiceCollection Section Starts Here

services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();

services.RegisterTransient<ISomeService, SomeServiceOne>();

//Register services in DiServiceCollection Section Ends Here

// Generate the container with our services
var container = services.GenerateContainer();

var serviceFirst = container.GetService<ISomeService>();
var serviceSecond = container.GetService<ISomeService>();

serviceFirst.PrintSomething();
serviceSecond.PrintSomething();
