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
    [EnableCors(origins: "http//localhost:4200", headers: "*", methods: "*")]
    public class SaldoCuentaController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["kepuaBDConexion"].ConnectionString;

        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dataTableResultado = new DataTable();
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM saldo_cuenta", conector);
                    adaptador.Fill(dataTableResultado);
                }
                catch (Exception)
                {
                }
            }
            return Ok(dataTableResultado);
        }


        // GET: api/Usuario/5
        public string Get(int id)
        {
            DataTable dataTableResultado = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT id_usuario, id_moneda, saldo, fecha, hora FROM saldo_cuenta WHERE id_saldo = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                //return dataTableResultado;
                return dataTableResultado.Rows[0]["id_usuario"].ToString();
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
                //return null;
            }
        }

        // POST: api/Rol
        public void Post([FromBody] Models.SaldoCuenta oSaldoCuenta)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO saldo_cuenta (id_usuario, id_moneda, saldo, fecha, hora) VALUES (" + oSaldoCuenta.Id_usuario + ", " + oSaldoCuenta.Id_moneda + ", " + oSaldoCuenta.Saldo + ", '"+ fecha + "', '" + hora + "')";
                                        comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                Console.Write("CATCH");
            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.SaldoCuenta oSaldoCuenta)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    string hora = DateTime.Now.ToString("hh:mm:ss");

                    conector.Open();
                    SqlCommand comando = new SqlCommand();

                    comando.CommandText = "UPDATE saldo_cuenta SET id_usuario = " + oSaldoCuenta.Id_usuario + ", id_moneda = " + oSaldoCuenta.Id_moneda + ", saldo = " + oSaldoCuenta.Saldo +
                        ", fecha = '"+ fecha +"', hora = '"+ hora +"' WHERE id_saldo = " + id;
                    comando.Connection = conector;

                    comando.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
            }
        }

        // DELETE: api/Rol/5
        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand("DELETE FROM saldo_cuenta WHERE id_saldo = " + id, conector);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
