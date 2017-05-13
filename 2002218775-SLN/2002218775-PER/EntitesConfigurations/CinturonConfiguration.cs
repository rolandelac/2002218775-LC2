using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;

namespace _2002218775_PER.EntitesConfigurations
{
    public class CinturonConfiguration : EntityTypeConfiguration<Cinturon>
    {
        public CinturonConfiguration()
        {
            //Table Configurations
            ToTable("Cinturones");

            HasKey(a => a.CinturonId);

            Property(a => a.NumSerie);
            Property(a => a.Metraje);

        }

    }
}
