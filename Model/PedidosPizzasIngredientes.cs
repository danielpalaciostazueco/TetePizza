using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TetePizza.Model;

public class PedidoPizzasIngredientes
{
    public PedidoPizzasIngredientes() { }
    [Key]
    public int IdOrder { get; set; }
    public Pedidos Pedidos { get; set; }
    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }
    public int IngredienteId { get; set; }
    public Ingredientes Ingrediente { get; set; }
    public int IdUser { get; set; }
    public string NameUser { get; set; }
    public Usuario User { get; set; }
}
