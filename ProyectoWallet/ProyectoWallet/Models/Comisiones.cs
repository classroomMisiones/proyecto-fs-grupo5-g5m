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
        public Double Porcentaje_comision { get; set; }
        public Double Monto_comision { get; set; }
        public string Fecha { get; set; }
    }
}