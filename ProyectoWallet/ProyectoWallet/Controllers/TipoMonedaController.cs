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
    public class TipoMonedaController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM tipo_moneda", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT nombre FROM tipo_moneda WHERE id_moneda = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                //return dataTableResultado;
                return dataTableResultado.Rows[0]["nombre"].ToString();
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
                //return null;
            }
        }

        // POST: api/Rol
        public void Post([FromBody] Models.TipoMoneda oTipoMoneda)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO tipo_moneda (nombre) VALUES ('" + oTipoMoneda.Nombre +"')";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.TipoMoneda oTipoMoneda)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE tipo_moneda SET nombre = '" + oTipoMoneda.Nombre + "' WHERE id_moneda = " + id;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM tipo_moneda WHERE id_moneda = " + id, conector);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
