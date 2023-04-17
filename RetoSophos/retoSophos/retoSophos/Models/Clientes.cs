using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace retoSophos.Models
{
    public class Clientes
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public char Estado { get; set; }
        public int Frecuencia { get; set; }
        public int Edad { get; set; }
    }
}