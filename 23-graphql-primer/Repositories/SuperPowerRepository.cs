using GraphQLPrimer.Data;
using GraphQLPrimer.Interfaces;

namespace GraphQLPrimer.Repositories;

public class SuperPowerRepository : ISuperPowerRepository
{
    private readonly SuperheroContext _superheroContext;

    public SuperPowerRepository(SuperheroContext context)
    {
        this._superheroContext = context;
    }
}