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
    public class TipoTransaccionController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["kepuaBDConexion"].ConnectionString;

        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dataTableResultado = new DataTable();
            try 
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                        conector.Open();
                        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM tipo_transaccion", conector);
                        adaptador.Fill(dataTableResultado);
                    
                }
            } 
            catch (Exception) 
            { 
            }
            
            return Ok(dataTableResultado);
        }


        // GET: api/Usuario/5
        public DataTable Get(int id)
        {
            DataTable dataTableResultado = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT descripcion, valor_comision FROM tipo_transaccion WHERE id_tipo_transaccion = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                return dataTableResultado;
                
            }
            catch (Exception)
            {
                return null; 
            }
        }

        // POST: api/Rol
        public void Post([FromBody] Models.TipoTransaccion oTipoTransaccion)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO tipo_transaccion (valor_comision, descripcion ) VALUES (" + oTipoTransaccion.Valor_comision + " , '" + oTipoTransaccion.Descripcion + "' )";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.TipoTransaccion oTipoTransaccion)
        {
            try 
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                        conector.Open();
                        SqlCommand comando = new SqlCommand();
                        comando.CommandText = "UPDATE tipo_transaccion SET descripcion = '" + oTipoTransaccion.Descripcion + "',  valor_comision = " + oTipoTransaccion.Valor_comision + " WHERE id_tipo_transaccion = " + id;
                        comando.Connection = conector;
                        //comando.BeginExecuteNonQuery();
                        comando.ExecuteNonQuery();
                    
                }
            } 
            catch (Exception) 
            { 
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
                    SqlCommand comando = new SqlCommand("DELETE FROM tipo_transaccion WHERE id_tipo_transaccion = " + id, conector);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
