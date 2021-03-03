using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using LOR.Pizzeria.Application.Interfaces;

using MediatR;

namespace LOR.Pizzeria.Application.Store.Queries
{
     public sealed class GetStoresQuery: IRequest<List<StoreDto>>
     {
         private static GetStoresQuery? _instance;
         
         public static GetStoresQuery Instance => _instance ??= new GetStoresQuery();
     }

     internal sealed class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, List<StoreDto>>
     {
         private readonly IApplicationDbContext _applicationDbContext;

         public GetStoresQueryHandler(IApplicationDbContext applicationDbContext)
         {
             _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
         }
         
         public Task<List<StoreDto>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
         {
             var stores = _applicationDbContext.Stores.Select(x => new StoreDto
             {
                 StoreId = x.Id,
                 StoreName = x.Name
             }).ToList();
             return Task.FromResult(stores);
         }
     }
}