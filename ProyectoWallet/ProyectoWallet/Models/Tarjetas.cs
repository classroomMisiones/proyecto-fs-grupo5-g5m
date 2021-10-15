using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class Tarjetas
    {
        public int Id_tarjeta { get; set; }
        public string Numero_tarjeta { get; set; }
        public string Fecha_vencimiento { get; set; }
        public int Id_usuario { get; set; }
    }
}