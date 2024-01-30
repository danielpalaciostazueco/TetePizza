using TetePizza.Model;
using TetePizza.Data;
using System.Collections.Generic;

namespace TetePizza.Services
{
    public class IngredientesService : IIngredientesService
    {
        private readonly IIngredientesRepository _ingredientesRepository;

        public IngredientesService(IIngredientesRepository ingredientesRepository)
        {
            _ingredientesRepository = ingredientesRepository;
        }

        public Ingredientes? Get(int id) => _ingredientesRepository.Get(id);
        public List<Ingredientes> GetAll() => _ingredientesRepository.GetAll();
        public void Add(Ingredientes ingredientes) => _ingredientesRepository.Add(ingredientes);
        public void Delete(int id) => _ingredientesRepository.Delete(id);
        public void Update(Ingredientes ingredientes) => _ingredientesRepository.Update(ingredientes);
    }
}
