using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class Comisiones
    {
        public int Id_comision { get; set; }
        public int Id_transaccion { get; set; }
        public int Id_moneda { get; set; }
        public float Porcentaje_comision { get; set; }
        public float Monto_comision { get; set; }
        public string Fecha { get; set; }
    }
}