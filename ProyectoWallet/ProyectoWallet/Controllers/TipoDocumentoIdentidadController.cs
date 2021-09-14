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
    public class TipoDocumentoIdentidadController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dataTableResultado = new DataTable();
            try 
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM tipo_documento_identidad", conector);
                    adaptador.Fill(dataTableResultado);
                }
            } 
            catch (Exception) 
            {
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT descripcion FROM tipo_documento_identidad WHERE id_tipo_dni = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                //return ok(dataTableResultado);
                return dataTableResultado.Rows[0]["descripcion"].ToString();
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
            }
        }

        // POST: api/Rol
        public void Post([FromBody] Models.TipoDocumento oTipoDocumento)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO tipo_documento_identidad (descripcion) VALUES ('" + oTipoDocumento.Descripcion + "')";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.TipoDocumento oTipoDocumento)
        {
            try { } catch (Exception) { }
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE tipo_documento_identidad SET descripcion = '" + oTipoDocumento.Descripcion + "' WHERE id_tipo_dni = " + id;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM tipo_documento_identidad WHERE id_tipo_dni = " + id, conector);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
