using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Psicologia.Models
{
    public class Reglas
    {
        public int IdRegla { get; set; }
        public int IdPersonalidadOcupacion { get; set; }
        public int IdAreaOcupacion { get; set; }
        public int IdCarrera1 { get; set; }
        public int IdCarrera2 { get; set; }
        public int IdCarrera3 { get; set; }
    }
}