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
    public class RolController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM rol", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT descripcion FROM rol WHERE id_rol = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                return dataTableResultado.Rows[0]["descripcion"].ToString();
                //return ok(dataTableResultado);
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
            }
            
        }

        // POST: api/Rol
        public void Post([FromBody] Models.Rol oRol)
        {
            try 
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                        conector.Open();
                        SqlCommand comando = new SqlCommand();
                        comando.CommandText = "INSERT INTO rol (descripcion) VALUES ('" + oRol.Descripcion + "')";
                        comando.Connection = conector;
                        comando.ExecuteNonQuery();
                }
            }
            catch (Exception) 
            {
           
            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.Rol oRol)
        {
            try 
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                        conector.Open();
                        SqlCommand comando = new SqlCommand();
                        comando.CommandText = "UPDATE rol SET descripcion = '" + oRol.Descripcion + "' WHERE id_rol = " + id;
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
                        SqlCommand comando = new SqlCommand("DELETE FROM rol WHERE id_rol = " + id, conector);
                        comando.ExecuteNonQuery();

                }
            }
            catch (Exception) 
            {
                //throw new KeyNotFoundException("No pudo completar la operacion, Id erroneo o inexistente");
            }
        }
    }
}
