using System;
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
    public class MailCrearCuentaController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["kepuaBDConexion"].ConnectionString;

        [HttpGet]
        // GET: api/MailCrearCuenta
        public int Get() // busco Id_mail
        {
            DataTable dataTableResultado = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_email FROM email WHERE Id_email = (SELECT MAX(Id_email) FROM email)", conector);
                    adaptador.Fill(dataTableResultado);
                    //var respuestaID = ;
                }
                return (int)dataTableResultado.Rows[0]["Id_email"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }
        
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/MailCrearCuenta/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/MailCrearCuenta
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/MailCrearCuenta/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/MailCrearCuenta/5
        //public void Delete(int id)
        //{
        //}
    }
}
