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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok(dataTableResultado);
        }

        [HttpGet]
        // GET: api/Usuario/5
        public IHttpActionResult Get(int id)
        {
            DataTable dataTableResultado = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_tipo_transaccion, Descripcion, Valor_comision FROM tipo_transaccion WHERE Id_tipo_transaccion = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok(dataTableResultado);
        }
        

        // POST: api/Rol
        public string Post([FromBody] Models.TipoTransaccion oTipoTransaccion)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO tipo_transaccion (Valor_comision, Descripcion ) VALUES (" + oTipoTransaccion.Valor_comision.ToString().Replace(",",".") + " , '" + oTipoTransaccion.Descripcion + "' )";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
                return "OPERACION DE INSERCION EXITOSA";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "NO SE PUDO COMPLETAR LA OPERACION  DE INSERCION";
            }
        }

        // PUT: api/Rol/5
        public string Put(int id, [FromBody] Models.TipoTransaccion oTipoTransaccion)
        {
            try 
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                        conector.Open();
                        SqlCommand comando = new SqlCommand();
                        comando.CommandText = "UPDATE tipo_transaccion SET Descripcion = '" + oTipoTransaccion.Descripcion + "',  Valor_comision = " + oTipoTransaccion.Valor_comision.ToString().Replace(",", ".") + " WHERE Id_tipo_transaccion = " + id;
                        comando.Connection = conector;
                        //comando.BeginExecuteNonQuery();
                        comando.ExecuteNonQuery();
                }
                return "OPERACION DE ACUALIZACION EXITOSA";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "NO SE PUDO COMPLETAR LA OPERACION DE ACUALIZACION";
            }

        }

        // DELETE: api/Rol/5
        public string Delete(int id)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand("DELETE FROM tipo_transaccion WHERE Id_tipo_transaccion = " + id, conector);
                    comando.ExecuteNonQuery();
                }
                return "OPERACION DE BORRADO EXITOSA";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw new KeyNotFoundException("No pudo completar la operacion, Id erroneo o inexistente");
                return "NO SE PUDO COMPLETAR LA OPERACION DE BORRADO";
            }
        }
    }
}
