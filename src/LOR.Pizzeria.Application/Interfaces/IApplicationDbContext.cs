using System.Linq;

using LOR.Pizzeria.Domain.Entities;

namespace LOR.Pizzeria.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        IQueryable<Domain.Entities.Store> Stores { get; }
        IQueryable<Recipe> Recipes { get; }
    }
}