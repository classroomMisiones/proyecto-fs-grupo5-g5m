using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class TipoTransaccion
    {
        public int Id_tipo_transaccion { get; set; }
        public string Descripcion { get; set; }
        public string Valor_comision { get; set; }

    }
}