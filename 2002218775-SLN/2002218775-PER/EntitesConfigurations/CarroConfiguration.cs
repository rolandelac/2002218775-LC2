using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;

namespace _2002218775_PER.EntitesConfigurations
{
    public class CarroConfiguration : EntityTypeConfiguration<Carro>
    {
        public CarroConfiguration()
        {
            //Table Configurations
            ToTable("Carros");

            HasKey(a => a.CarroId);

            Property(a => a.NumSerieMotor);
            Property(a => a.NumSerieChasis);

            //Relations Configurations

            //relacion agregacion (1 a 1)
            HasRequired(c => c.Parabrisas)
                .WithRequiredPrincipal(c => c.Carro);
            
            //relacion agregacion (1 a 1)
            HasRequired(c => c.Volante)
                .WithRequiredPrincipal(c => c.Carro);

            //relacion herencia: automovil hereda de carro
            Map<Automovil>(m => m.Requires("Discriminator").HasValue("Automovil"));

            //relacion composicion (1 a *)
            HasRequired(c => c.Ensambladora)
                .WithMany(c => c.Carros);

            //herencia: bus hereda de carro
            Map<Bus>(m => m.Requires("Discriminator").HasValue("Bus"));

            //relacion agregacion (1 a 1)
            HasRequired(c => c.Propietario)
                .WithRequiredPrincipal(c => c.Carro);


        }
    }
}
