using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class Usuario
    {

        public int Id_usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni_numero { get; set; }
        public int Id_tipo_dni { get; set; }
        public string Direccion { get; set; }
        public int Nro_direccion { get; set; }
        public string Piso_departamento { get; set; }
        public int Id_email { get; set; }
        public int Id_telefono { get; set; }
        public int Id_pais { get; set; }
        public int Id_provincia { get; set; }
        public int Id_localidad { get; set; }
        public int Id_estado_cuenta { get; set; }
        public int Id_rol { get; set; }
        public string Clave { get; set; }
        public string Fecha_clave { get; set; }
        public string Nombre_de_usuario { get; set; }
        public string Token { get; set; }

    }
}