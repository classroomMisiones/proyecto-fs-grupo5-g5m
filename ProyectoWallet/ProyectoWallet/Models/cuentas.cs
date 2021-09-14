using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class Cuentas
    {
        public int Id_cuenta { get; set; }
        public int Cvu { get; set; }
        public int Id_usuario { get; set; }
        public int Id_estado_cuenta { get; set; }
    }
}