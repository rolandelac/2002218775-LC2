using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;
using _2002218775_ENT.IRepositories;

namespace _2002218775_PER.Repositories
{
    public class PropietarioRepository : Repository<Propietario>, IPropietarioRepository
    {
        private readonly _2002218775DbContext _Context;

        public PropietarioRepository(_2002218775DbContext context)
        {
            _Context = context;
        }

        private PropietarioRepository()
        {

        }
    }
}
