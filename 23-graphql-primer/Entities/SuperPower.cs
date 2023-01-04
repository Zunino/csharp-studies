using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLPrimer.Entities;

public class SuperPower
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "The name of the super power is required")]
    public string Name { get; set; }
    public string Description { get; set; }
    [ForeignKey("SuperheroId")]
    public Guid SuperheroId { get; set; }
    public Superhero Superhero { get; set; }  
}