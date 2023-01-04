using GraphQLPrimer.Data;
using GraphQLPrimer.Entities;

namespace GraphQLPrimer.GraphQL;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Superhero> GetSuperheroes([Service] SuperheroContext context) =>
        context.Superheroes;
}