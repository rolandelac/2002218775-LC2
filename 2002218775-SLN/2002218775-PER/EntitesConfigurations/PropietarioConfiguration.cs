using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;

namespace _2002218775_PER.EntitesConfigurations
{
    public class PropietarioConfiguration : EntityTypeConfiguration<Propietario>
    {
        public PropietarioConfiguration()
        {
            //Table Configurations
            ToTable("Asientos");

            HasKey(a => a.PropietarioId);

            Property(a => a.DNI);
            Property(a => a.Nombres);
            Property(a => a.Apellidos);
            Property(a => a.LicenciaConducir);

        }
    }
}
