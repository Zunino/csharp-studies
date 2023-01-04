using System.ComponentModel.DataAnnotations;

namespace GraphQLPrimer.Entities;

public class Superhero
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "What's the name of the superhero?")]
    public string Name { get; set; }
    public string Description { get; set; }
    public double Height { get; set; }
    public ICollection<SuperPower> SuperPowers { get; set; }
    public ICollection<Movie> Movies { get; set; }
}