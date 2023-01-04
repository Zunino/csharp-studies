using GraphQLPrimer.Data;
using GraphQLPrimer.Interfaces;

namespace GraphQLPrimer.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly SuperheroContext _superheroContext;

    public MovieRepository(SuperheroContext context)
    {
        this._superheroContext = context;
    }
}