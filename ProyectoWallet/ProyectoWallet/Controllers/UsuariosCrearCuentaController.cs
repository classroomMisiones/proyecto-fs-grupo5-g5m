using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoWallet.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsuariosCrearCuentaController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["kepuaBDConexion"].ConnectionString;
        
        [HttpGet] //BUSCO ID USUARIO
        // GET: api/Usuario
        public int GetIdUsuario()
        {
            DataTable dataTableResultado = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_usuario FROM usuarios WHERE Id_usuario = (SELECT MAX(Id_usuario) FROM usuarios)", conector);
                    adaptador.Fill(dataTableResultado);
                    //var respuestaID = ;
                }
                return (int)dataTableResultado.Rows[0]["Id_usuario"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }


        //// GET: api/UsuariosCrearCuenta/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/UsuariosCrearCuenta
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/UsuariosCrearCuenta/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/UsuariosCrearCuenta/5
        //public void Delete(int id)
        //{
        //}



    }
}
