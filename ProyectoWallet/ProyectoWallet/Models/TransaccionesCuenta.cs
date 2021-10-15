using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class TransaccionesCuenta
    {
        public int Id_transaccion { get; set; }
        public int Id_usuario { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int Id_tipo_transaccion { get; set; }
        public int Id_cuenta_origen { get; set; }
        public int Id_moneda_origen { get; set; }
        public Double Monto_origen { get; set; }
        public int Id_cuenta_destino { get; set; }
        public int Id_moneda_destino { get; set; }
        public Double Monto_destino { get; set; }
    }
}