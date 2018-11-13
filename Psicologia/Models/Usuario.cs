using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Psicologia.Models
{
    public class Usuario
    {
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string Dni { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Id_Rol { get; set; }
        public string NombreApoderado { get; set; }
        public string TelefonoApoderado { get; set; }
        public string NombresMadre { get; set; }
        public string NombresPadre { get; set; }
    }
}