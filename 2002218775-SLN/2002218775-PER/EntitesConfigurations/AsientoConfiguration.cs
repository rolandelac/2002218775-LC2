using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;

namespace _2002218775_PER.EntitesConfigurations
{
    public class AsientoConfiguration : EntityTypeConfiguration<Asiento>
    {

        public AsientoConfiguration()
        {
            //Table Configurations
            ToTable("Asientos");

            HasKey(a => a.AsientoId);

            Property(a => a.NumSerie);

            //Relations Configurations

            //relacion agregacion (1 a 1)
            //en este caso asiento jala el ID de cinturon
            HasRequired(c => c.Cinturon)
                .WithRequiredPrincipal(c => c.Asiento);

            //relacion composicion (1 a *)
            HasRequired(c => c.Carro)
                .WithMany(c => c.Asientos);
        }

    }
}
