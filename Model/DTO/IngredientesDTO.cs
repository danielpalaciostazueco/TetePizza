using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TetePizza.Model;

public class IngredientesDTO
{
    public int IngredienteId { get; set; }
    public string Nombre { get; set; }
}
