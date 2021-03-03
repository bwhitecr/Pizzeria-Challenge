using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using LOR.Pizzeria.Application.Interfaces;

using MediatR;

namespace LOR.Pizzeria.Application.Menu.Queries
{
    public sealed class GetStoreMenu : IRequest<List<PizzaDto>>
    {
        public string StoreId { get; }

        public static GetStoreMenu ForStore(string storeId) => new GetStoreMenu(storeId);
        
        private GetStoreMenu(string storeId) => StoreId = storeId;
    }

    internal sealed class GetStoreMenuHandler : IRequestHandler<GetStoreMenu, List<PizzaDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetStoreMenuHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public Task<List<PizzaDto>> Handle(GetStoreMenu request, CancellationToken cancellationToken)
        {
            var menu = _dbContext.Stores.Where(x => x.Id == request.StoreId)
                .SelectMany(x => x.Pizzas)
                .Select(x => new PizzaDto
                {
                    PizzaId = x.Recipe.Id,
                    PizzaName = x.Recipe.Name,
                    Price = x.BasePrice,
                    Toppings = x.Recipe.Toppings.Select(t => t.Name).ToList()
                })
                .OrderBy(x => x.PizzaName)
                .ToList();

            return Task.FromResult(menu);
        }
    }
}