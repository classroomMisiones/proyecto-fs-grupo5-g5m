using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class Telefono
    {
        public int Id_telefono { get; set; }
        public string Numero_telefono { get; set; }
        public int Id_usuario { get; set; }

    }
}