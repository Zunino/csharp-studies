using GraphQLPrimer.Entities;
using GraphQLPrimer.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLPrimer.Controllers;

[Route("superheroes")]
public class SuperheroController
{
    private readonly ISuperheroRepository _superheroRepository;
    
    public SuperheroController(ISuperheroRepository superheroRepository)
    {
        this._superheroRepository = superheroRepository;
    }
    
    [HttpGet]
    public IEnumerable<Superhero> Home()
    {
        return _superheroRepository.FetchAll();
    }
}