using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWallet.Models
{
    public class LoginRequest
    {
        public string Mail { get; set; }
        public string Clave { get; set; }
    }
}