using TetePizza.Model;
using TetePizza.Data;
using System.Collections.Generic;

namespace TetePizza.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidosService(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public void Add(Pedidos pedido)
        {
            _pedidosRepository.Add(pedido);
        }

        public PedidosDTO Get(int id)
        {
            return _pedidosRepository.Get(id);
        }

        public void Update(Pedidos pedido)
        {
            _pedidosRepository.Update(pedido);
        }

        public void Delete(int id)
        {
            _pedidosRepository.Delete(id);
        }

        public List<PedidosDTO> GetAll()
        {
            return _pedidosRepository.GetAll();
        }
    }
}
