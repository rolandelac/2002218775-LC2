using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2002218775_ENT
{
    public class Automovil:Carro
    {

        public int AutomovilId { get; set; }

        public TipoAuto TipoAuto { get; set; }

        public Automovil(Volante volante, Parabrisa parabrisa, int numLlantas,
                         int numAsientos, Propietario propietario, TipoCarro tipoCarro, TipoAuto tipoAuto)
            : base(volante, parabrisa, numLlantas, numAsientos, propietario, tipoCarro)
        {
            TipoAuto = tipoAuto;
        }

        public Automovil()
        {
            TipoAuto = TipoAuto.NoDefinido;
        }
    }
}
