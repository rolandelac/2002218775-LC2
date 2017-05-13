using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;

namespace _2002218775_PER.EntitesConfigurations
{
    public class EnsambladoraConfiguration : EntityTypeConfiguration<Ensambladora>
    {
        public EnsambladoraConfiguration()
        {
            //Table Configurations
            ToTable("Ensambladora");

            HasKey(a => a.EnsambladoraId);

            //Relations Configurations

        }

    }
}
