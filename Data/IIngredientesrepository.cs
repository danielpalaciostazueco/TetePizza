using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Data
{
    public interface IIngredientesRepository
    {
      Ingredientes Get(int id);
      List<Ingredientes> GetAll();

    }
}
