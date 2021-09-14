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
    public class EmailController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM email", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT mail FROM email WHERE id_email = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                return dataTableResultado.Rows[0]["mail"].ToString();
                
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
            }

        }

        // POST: api/Rol
        public void Post([FromBody] Models.Email oEmail)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO email (mail, id_usuario) VALUES ('" + oEmail.Mail + "', " + oEmail.Id_usuario + ")";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.Email oEmail)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE email SET mail = '" + oEmail.Mail + "', id_usuario = "+ oEmail.Id_usuario + " WHERE id_email = " + id;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM email WHERE id_email = " + id, conector);
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
