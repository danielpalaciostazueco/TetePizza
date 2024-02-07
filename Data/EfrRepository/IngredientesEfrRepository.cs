using TetePizza.Model;
using Microsoft.EntityFrameworkCore;

namespace TetePizza.Data
{
    public class IngredientesEfrRepository : IIngredientesRepository
    {
        private readonly TetePizzaAppContext _context;

        public IngredientesEfrRepository(TetePizzaAppContext context)
        {
            _context = context;
        }

        public List<Ingredientes> GetAll()
        {
            return _context.Ingredientes.ToList();
            SaveChanges();
        }

        public Ingredientes Get(int Id)
        {
            return _context.Ingredientes.FirstOrDefault(ingredientes => ingredientes.IdIngredient == Id);
            SaveChanges();
        }


        public void Add(Ingredientes ingredientes)
        {
            _context.Ingredientes.Add(ingredientes);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var ingredientes = _context.Ingredientes.FirstOrDefault(ingredientes => ingredientes.IdIngredient == id);
            if (ingredientes != null)
            {
                _context.Ingredientes.Remove(ingredientes);
            }
            SaveChanges();
        }

        public void Update(Ingredientes ingredientes)
        {
            _context.Ingredientes.Update(ingredientes);
            SaveChanges();
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}