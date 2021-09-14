using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class LoginUsuarios
    {
        public int Id_login { get; set; }
        public int Id_usuario { get; set; }
        public string Fecha_hora_inicio { get; set; }
        public string Fecha_hora_final { get; set; }
    }
}