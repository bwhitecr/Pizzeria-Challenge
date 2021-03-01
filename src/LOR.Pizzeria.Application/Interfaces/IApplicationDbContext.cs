using System.Linq;

using LOR.Pizzeria.Domain.Entities;

namespace LOR.Pizzeria.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        IQueryable<Store> Stores { get; }
        IQueryable<Recipe> Recipes { get; }
    }
}