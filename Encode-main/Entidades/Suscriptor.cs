﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class Suscriptor
    {
        public int IdSuscriptor { get; set; }
        public string NombreSuscriptor { get; set; }
        public string ApellidoSuscriptor { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Direccion { get; set; }
        public string NroTelefono { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }






    }
}
