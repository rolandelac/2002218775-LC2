using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2002218775_ENT.IRepositories
{
    public interface IAutomovilRepository : IRepository<Automovil>
    {
        //Obtener la relacion de automoviles deacuerdo a su tipo
        IEnumerable<Automovil> GetClassificatedAuthors(TipoAuto TipoAuto);

    }
}
