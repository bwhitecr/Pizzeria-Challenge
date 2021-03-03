using System;

using LOR.Pizzeria.Application;
using LOR.Pizzeria.Infrastructure;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using Moq.AutoMock;

using NUnit.Framework;

namespace PizzeriaTests
{
    public abstract class TestBase
    {
        private readonly ServiceProvider _serviceProvider;
        private IServiceScope _scope;

        protected TestBase()
        {
            var services = new ServiceCollection();
            _serviceProvider = services
                .AddInfrastructureServices()
                .AddApplicationServices()
                .AddMediatR(typeof(TestBase))
                .BuildServiceProvider();
        }
        
        [SetUp]
        public void Setup()
        {
            _scope = _serviceProvider.CreateScope();
        }

        [TearDown]
        public void TearDown()
        {
            _scope.Dispose();
        }

        protected IServiceProvider Services => _scope.ServiceProvider;

        protected AutoMocker AutoMocker = new AutoMocker();
    }
}