using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoWallet.Controllers
{
    public class EstadoCuentaController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dataTableResultado = new DataTable();
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM estado_cuenta", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT nombre FROM estado_cuenta WHERE id_estado_cuenta = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                //return ok(dataTableResultado);
                return dataTableResultado.Rows[0]["nombre"].ToString();
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
            }
        }

        // POST: api/Rol
        public void Post([FromBody] Models.EstadoCuenta oEstadoCuenta)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO estado_cuenta (nombre) VALUES ('" + oEstadoCuenta.Nombre +"')";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.EstadoCuenta oEstadoCuenta)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE estado_cuenta SET nombre= '" + oEstadoCuenta.Nombre + "' WHERE id_estado_cuenta = " + id;
                    comando.Connection = conector;
                    //comando.BeginExecuteNonQuery();
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
                    SqlCommand comando = new SqlCommand("DELETE FROM estado_cuenta WHERE id_estado_cuenta = " + id, conector);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
