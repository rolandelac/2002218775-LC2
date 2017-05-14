using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2002218775_ENT
{
    public class Bus :Carro
    {
        public int BusId { get; set; }

        public TipoBus TipoBus { get; set; }


        public Bus(Volante volante, Parabrisas parabrisa, int numLlantas,
                         int numAsientos, Propietario propietario, TipoCarro tipoCarro, TipoBus tipoBus)
            : base(volante, parabrisa, numLlantas, numAsientos, propietario, tipoCarro)
        {
            TipoBus = tipoBus;
        }

        public Bus()
        {

        }
    }
}
