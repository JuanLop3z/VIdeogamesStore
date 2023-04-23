using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace retoSophos.Models
{
    public class Juegos
    { 
        public string Nombre { get; set;}
        public int Precio { get; set;}
        public string Frecuencia { get; set;}
        public string Plataforma { get; set;}
        public string Director { get; set;}
        public string Protagonistas { get; set;}
        public string ProductorMarca { get; set;}
        public string FechaLanzamiento { get; set;}
        public string Estado { get; set;}
        public DateTime Fechaalquiler { get; set;}


    }
}