using System.Threading.Tasks;

using FluentAssertions;

using LOR.Pizzeria.Application.Store.Queries;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

namespace PizzeriaTests.Store.Queries
{
    [TestFixture]
    public class GetStoresTests : TestBase
    {
        [Test]
        public async Task GetStoresQuery_Returns_Non_Empty_List_Of_Stores()
        {
            var mediator = Services.GetRequiredService<IMediator>();

            var stores = await mediator.Send(GetStores.Instance);

            stores.Should().NotBeNullOrEmpty();
        }
    }
}