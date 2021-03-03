using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using LOR.Pizzeria.Application.Store.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace LOR.Pizzeria.Controllers
{
    /// <summary>
    /// API to provide the caller the stores that are available.
    /// </summary>
    [ApiController]
    [Route("api/store")]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        /// <summary>
        /// Retrieves the stores that are available.
        /// </summary>
        /// <returns>A list of <see cref="StoreDto"/> objects.</returns>
        [HttpGet]
        public async Task<IEnumerable<StoreDto>> Get()
        {
            return await _mediator.Send(GetStores.Instance, CancellationToken.None);
        }
    }
}