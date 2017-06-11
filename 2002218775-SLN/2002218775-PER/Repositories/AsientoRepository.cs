using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;
using _2002218775_ENT.IRepositories;

namespace _2002218775_PER.Repositories
{
    public class AsientoRepository : Repository<Asiento>, IAsientoRepository
    {
        public AsientoRepository(_2002218775DbContext context) : base(context)
        {
        }
    }
}
