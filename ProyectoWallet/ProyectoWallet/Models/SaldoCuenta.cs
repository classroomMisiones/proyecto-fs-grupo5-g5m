using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class SaldoCuenta
    {
        public int Id_saldo { get; set; }
        public int Id_usuario { get; set; }
        public int Id_moneda { get; set; }
        public float Saldo { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    }
}