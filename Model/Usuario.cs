using System.ComponentModel.DataAnnotations;
namespace TetePizza.Model;

public class Usuario
{
    public Usuario() { }
    [Key]
    public int IdUser { get; set; }
    public string? NameUser { get; set; }

    public string? AdressUser { get; set; }
}