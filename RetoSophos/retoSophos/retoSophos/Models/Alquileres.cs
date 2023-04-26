using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace retoSophos.Models
{
    public class Alquileres
    {
        public int IdAlquiler { get; set; }
        public int IdJuego { get; set; }
        public string NombreJuego { get; set; }
        public string IdCliente { get; set; }
        public Boolean Estado { get; set; }
        public DateTime Fecha { get; set;}
    }
}