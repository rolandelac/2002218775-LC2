using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2002218775_ENT.IRepositories
{
    public interface IParabrisasRepository : IRepository<Parabrisas>
    {
        //obtner la relacion de pedido por tipo de cliente
        //IEnumerable<Pedido> GetPedidoTipoClientes(TipoCliente tipoCliente);
    }
}
