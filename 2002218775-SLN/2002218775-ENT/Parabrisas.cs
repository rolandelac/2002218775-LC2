using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2002218775_ENT
{
    public class Parabrisas
    {
        public int ParabrisasId { get; set; }

        public string NumSerie { get; set; }

        public int CarroId { get; set; }
        public Carro Carro { get; set; }

    }
}
