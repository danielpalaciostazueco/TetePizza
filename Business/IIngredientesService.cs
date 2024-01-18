using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Services
{
    public interface IIngredientesService
    {
      Ingredientes Get(int id);
      List<Ingredientes> GetAll();

    }
}
