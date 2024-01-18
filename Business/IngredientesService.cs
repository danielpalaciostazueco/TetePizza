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
    }
}
