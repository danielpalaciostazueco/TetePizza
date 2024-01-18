using TetePizza.Model;
using TetePizza.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TetePizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosService _pedidosService;

        public PedidosController(PedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [HttpGet("{id}")]
        public ActionResult<Pedidos> Get(int id)
        {
            var pedido = _pedidosService.Get(id);

            if (pedido == null)
                return NotFound();

            return pedido;
        }

        [HttpPost]
        public IActionResult Create(Pedidos pedido)
        {
            if (pedido.Pizzas != null && pedido.Pizzas.Any())
            {
                pedido.Price = pedido.Pizzas.Sum(p => p.Price);
            }

            _pedidosService.Add(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.IdOrder }, pedido);
        }

        [HttpPut("{id}/add-pizzas")]
        public IActionResult AddPizzas(int id, List<Pizza> pizzas)
        {
            _pedidosService.AddPizzas(id, pizzas);
            return NoContent();
        }
    }
}
