using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TetePizza.Model;

public class PedidosDTO
{
    public PedidosDTO() { }

    [Key]
    public int idOrder { get; set; }
    public int IdUser { get; set; }
    public string NameUser { get; set; }
    public int PizzaId { get; set; }
    public string Nombre { get; set; }
    public List<PizzaDTO> Pizzas { get; set; }
    public List<IngredientesDTO> Ingredientes { get; set; }
}
