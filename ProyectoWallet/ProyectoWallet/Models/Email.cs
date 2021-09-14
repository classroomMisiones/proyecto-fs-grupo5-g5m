using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class Email
    {
        public int Id_email { get; set; }
        public string Mail { get; set; }
        public int Id_usuario { get; set; }
    }
}