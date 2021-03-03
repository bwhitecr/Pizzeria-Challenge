using System;
using System.Threading.Tasks;

using FluentAssertions;

using LOR.Pizzeria.Application.Store.Queries;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

namespace PizzeriaTests.Store.Queries
{
    [TestFixture]
    public class GetStoresQueryTests : TestBase
    {
        private IServiceScope _scope;
        private IServiceProvider _services;
        
        [SetUp]
        public void Setup()
        {
            _scope = base.CreateServiceScope();
            _services = _scope.ServiceProvider;
        }

        [TearDown]
        public void TearDown()
        {
            _scope.Dispose();
        }

        [Test]
        public async Task GetStoresQuery_Returns_Non_Empty_List_Of_Stores()
        {
            var mediator = _services.GetRequiredService<IMediator>();

            var stores = await mediator.Send(GetStoresQuery.Instance);

            stores.Should().NotBeNullOrEmpty();
        }
    }
}