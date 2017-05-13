using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2002218775_ENT
{
    public class Ensambladora
    {
        public int EnsambladoraId { get; set; }

        public List<Carro> Carros { get; set; }

        public Ensambladora()
        {
            Carros = new List<Carro>();
        }
    }
}
