using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class Localidad
    {
        public int Id_localidad { get; set; }
        public string Nombre { get; set; }
        public int Id_provincia { get; set; }
    }
}