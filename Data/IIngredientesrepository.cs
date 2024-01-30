using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Data
{
    public interface IIngredientesRepository
    {
      Ingredientes Get(int id);
      List<Ingredientes> GetAll();
      void Add(Ingredientes ingredientes);
      void Delete(int id);
      void Update(Ingredientes ingredientes);
    }
}
