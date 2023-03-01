using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class Contacto
    {
        public int IdContacto { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Telefono { get; set; }
        public String Correo { get; set; }


    }
}