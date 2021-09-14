using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class CuentasHistorialEstado
    {
        public int Id_historia_cuenta { get; set; }
        public string Fecha_hora { get; set; }
        public string Estado { get; set; }
        public int Id_cuenta { get; set; }
        public int Id_usuario { get; set; }
    }
}