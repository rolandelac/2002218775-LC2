using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT.IRepositories;

namespace _2002218775_PER.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly _2002218775DbContext _Context;



        public IAsientoRepository Asientos { get; private set; }



        public ICarroRepository Carros { get; private set; }

        public ICinturonRepository Cinturones { get; private set; }


        public ILlantaRepository Llantas { get; private set; }

        public IParabrisasRepository Parabrisas { get; private set; }

        public IPropietarioRepository Propietarios { get; private set; }

        public IVolanteRepository Volantes { get; private set; }

        private UnityOfWork()
        {
            _Context = new _2002218775DbContext();

            Asientos = new AsientoRepository(_Context);
            Carros = new CarroRepository(_Context);
            Cinturones = new CinturonRepository(_Context);
            Llantas = new LlantaRepository(_Context);
            Parabrisas = new ParabrisasRepository(_Context);
            Propietarios = new PropietarioRepository(_Context);
            Volantes = new VolanteRepository(_Context);

        }



        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }
    }
}
