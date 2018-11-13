using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Psicologia.Models
{
    public class Pregunta
    {
        public string idPregunta { get; set; }
        public string idTest { get; set; }
        public string idSeccion { get; set; }
        public string idPersonalidadOcupacion { get; set; }
        public int Enunciado { get; set; }
        public int Item { get; set; }
        public string Preguntaa { get; set; }
    }
}