using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;
using _2002218775_PER.EntitesConfigurations;

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

        public DbSet<Parabrisas> Parabrisas { get; set; }

        public DbSet<Propietario> Propietarios { get; set; }

        public DbSet<Volante> Volantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AsientoConfiguration());
            modelBuilder.Configurations.Add(new AutomovilConfiguration());
            modelBuilder.Configurations.Add(new BusConfiguration());
            modelBuilder.Configurations.Add(new CarroConfiguration());
            modelBuilder.Configurations.Add(new CinturonConfiguration());
            modelBuilder.Configurations.Add(new EnsambladoraConfiguration());
            modelBuilder.Configurations.Add(new LlantaConfiguration());
            modelBuilder.Configurations.Add(new ParabrisaConfiguration());
            modelBuilder.Configurations.Add(new PropietarioConfiguration());
            //modelBuilder.Configurations.Add(new TipoAutoConfiguration());
            //modelBuilder.Configurations.Add(new TipoBusConfiguration());
            //modelBuilder.Configurations.Add(new TipoCarroConfiguration());
            modelBuilder.Configurations.Add(new VolanteConfiguration());


            base.OnModelCreating(modelBuilder);
        }



    }
}
