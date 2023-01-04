using GraphQLPrimer.Data;
using GraphQLPrimer.Entities;
using GraphQLPrimer.Interfaces;

namespace GraphQLPrimer.Repositories;

public class SuperheroRepository : ISuperheroRepository
{
    private readonly SuperheroContext _superheroContext;

    public SuperheroRepository(SuperheroContext context)
    {
        this._superheroContext = context;
    }

    public IEnumerable<Superhero> FetchAll()
    {
        return _superheroContext.Superheroes;
    }
}