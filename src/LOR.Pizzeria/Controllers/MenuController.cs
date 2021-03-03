using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using LOR.Pizzeria.Application.Menu.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace LOR.Pizzeria.Controllers
{
    /// <summary>
    /// Provides the menu for a store
    /// </summary>
    [ApiController]
    [Route("api/menu/{storeId}")]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        /// <summary>
        /// Gets the pizzas that are on the menu for the store.
        /// </summary>
        /// <param name="storeId">The identifier of the store.</param>
        /// <returns>A list of <see cref="PizzaDto"/> that are on the menu of the selected store.</returns>
        [HttpGet]
        public async Task<IEnumerable<PizzaDto>> Get(string storeId)
        {
            return await _mediator.Send(GetStoreMenu.ForStore(storeId));
        }
    }
}