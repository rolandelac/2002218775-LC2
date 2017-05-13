using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;

namespace _2002218775_PER.EntitesConfigurations
{
    public class VolanteConfiguration : EntityTypeConfiguration<Volante>
    {
        public VolanteConfiguration()
        {
            //Table Configurations
            ToTable("Volante");

            HasKey(a => a.VolanteId);

            Property(a => a.NumSerie);
        }
    }
}
