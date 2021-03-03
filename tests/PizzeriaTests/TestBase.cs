using LOR.Pizzeria.Application;
using LOR.Pizzeria.Infrastructure;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using Moq.AutoMock;

namespace PizzeriaTests
{
    public abstract class TestBase
    {
        private ServiceProvider _serviceProvider;

        protected TestBase()
        {
            var services = new ServiceCollection();
            _serviceProvider = services
                .AddInfrastructureServices()
                .AddApplicationServices()
                .AddMediatR(typeof(TestBase))
                .BuildServiceProvider();
        }

        protected IServiceScope CreateServiceScope() => _serviceProvider.CreateScope();

        protected AutoMocker AutoMocker = new AutoMocker();
    }
}