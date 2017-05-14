using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT.IRepositories;

namespace _2002218775_PER.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
