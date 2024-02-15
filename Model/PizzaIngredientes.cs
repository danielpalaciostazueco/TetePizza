using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TetePizza.Model;

public class PizzaIngredientes
{
    public PizzaIngredientes() { }
    [Key]
    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }
    public int IngredienteId { get; set; }
    public Ingredientes Ingrediente { get; set; }
}
