using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Services
{
    public interface IPedidosService
    {
        void Add(Pedidos pedidos);
        PedidosDTO Get(int id);

        void Update(Pedidos pedidos);

        void Delete(int id);

        List<PedidosDTO> GetAll();
    }
}
