using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;

namespace _2002218775_PER
{
    public class _2002218775DbContext : DbContext
    {
        public DbSet<Asiento> Asientos { get; set; }

        public DbSet<Automovil> Automoviles { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Carro> Carros { get; set; }

        public DbSet<Cinturon> Cinturones { get; set; }

        public DbSet<Ensambladora> Ensambladoras { get; set; }

        public DbSet<Llanta> Llantas { get; set; }

        public DbSet<Parabrisa> Parabrisas { get; set; }

        public DbSet<Propietario> Propietarios { get; set; }

        public DbSet<Volante> Volantes { get; set; }





    }
}
