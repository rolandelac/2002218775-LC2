using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2002218775_API.DTO
{
    public class PropietariosDto
    {
        public int PropietarioId { get; set; }

        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string LicenciaConducir { get; set; }

        public int CarroId { get; set; }
        //public Carro Carro { get; set; }
    }
}