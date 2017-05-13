using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2002218775_ENT;

namespace _2002218775_PER.EntitesConfigurations
{
    public class BusConfiguration : EntityTypeConfiguration<Bus>
    {
        public BusConfiguration()
        {
            //Table Configurations
            ToTable("Buses");

            HasKey(a => a.BusId);

        }
    }
}
