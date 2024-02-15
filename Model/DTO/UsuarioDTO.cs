using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TetePizza.Model;

public class UsuarioDTO
{
    public int IdUser { get; set; }
    public string Nombre { get; set; }
}
