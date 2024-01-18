using TetePizza.Model;
using TetePizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace TetePizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientesController : ControllerBase
    {
        private readonly IngredientesService _ingredientesService;

        public IngredientesController(IngredientesService ingredientesService)
        {
            _ingredientesService = ingredientesService;
        }

        [HttpGet]
        public ActionResult<List<Ingredientes>> GetAll() =>
            _ingredientesService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Ingredientes?> Get(int id)
        {
            var ingredientes = _ingredientesService.Get(id);

            if (ingredientes == null)
                return NotFound();

            return ingredientes;
        }
    }
}
