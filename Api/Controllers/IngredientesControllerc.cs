using TetePizza.Model;
using TetePizza.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpPost]
        public IActionResult Add(Ingredientes ingredientes)
        {
            _ingredientesService.Add(ingredientes);
            return CreatedAtAction(nameof(Get), new { id = ingredientes.IdIngredient }, ingredientes);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ingredientes = _ingredientesService.Get(id);

            if (ingredientes == null)
                return NotFound();

            _ingredientesService.Delete(id);

            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Ingredientes ingredientes)
        {
            if (id != ingredientes.IdIngredient)
                return BadRequest();

            var existingIngredientes = _ingredientesService.Get(id);
            if (existingIngredientes is null)
                return NotFound();

            _ingredientesService.Update(ingredientes);

            return NoContent();
        }
    }
}
