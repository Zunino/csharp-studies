using GraphQLPrimer.Entities;

namespace GraphQLPrimer.Interfaces;

public interface ISuperheroRepository
{
    IEnumerable<Superhero> FetchAll();
}