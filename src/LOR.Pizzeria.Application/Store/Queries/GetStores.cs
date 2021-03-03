using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using LOR.Pizzeria.Application.Interfaces;

using MediatR;

namespace LOR.Pizzeria.Application.Store.Queries
{
     public sealed class GetStores: IRequest<List<StoreDto>>
     {
         private static GetStores? _instance;
         
         public static GetStores Instance => _instance ??= new GetStores();
     }

     internal sealed class GetStoresHandler : IRequestHandler<GetStores, List<StoreDto>>
     {
         private readonly IApplicationDbContext _applicationDbContext;

         public GetStoresHandler(IApplicationDbContext applicationDbContext)
         {
             _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
         }
         
         public Task<List<StoreDto>> Handle(GetStores request, CancellationToken cancellationToken)
         {
             var stores = _applicationDbContext.Stores
                 .Select(x => new StoreDto
             {
                 StoreId = x.Id,
                 StoreName = x.Name
             })
                 .OrderBy(x => x.StoreName)
                 .ToList();
             return Task.FromResult(stores);
         }
     }
}