using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TetePizza.Model;

public class PizzaDTO
{
    public int PizzaId { get; set; }
    public string Nombre { get; set; }
    public List<IngredientesDTO> Ingredientes { get; set; }
}
