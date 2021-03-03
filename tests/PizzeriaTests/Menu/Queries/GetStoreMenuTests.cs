using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using LOR.Pizzeria.Application.Interfaces;
using LOR.Pizzeria.Application.Menu.Queries;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

namespace PizzeriaTests.Menu.Queries
{
    public class GetStoreMenuTests : TestBase
    {

        private async Task<List<PizzaDto>> Act(string storeId)
        {
            var mediator = Services.GetRequiredService<IMediator>();

            return await mediator.Send(GetStoreMenu.ForStore(storeId));
        }
        
        [Test]
        public async Task GetStoreMenu_Query_Returns_Empty_List_When_Store_Not_Found()
        {
            var menu = await Act(Guid.NewGuid().ToString());
            menu.Should().BeEmpty();
        }

        [Test]
        public async Task GetStoreMenu_Query_For_Brisbane_Returns_Three_Pizzas()
        {
            // Because we are using a fake database we know exactly the count of items.
            // In a real world scenario we would use an in-memory database and seed it with our test data.
            var dbContext = Services.GetRequiredService<IApplicationDbContext>();
            var brisbaneStore = dbContext.Stores.First(x => x.Name == "Brisbane");

            var menu = await Act(brisbaneStore.Id);
            menu.Should().HaveCount(3);
        }
    }
}