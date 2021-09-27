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
    public class LoginUsuariosController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM login_usuarios", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT id_usuario, fecha_hora_inicio, fecha_hora_final FROM login_usuarios WHERE id_login = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                //return dataTableResultado;
                return dataTableResultado.Rows[0]["id_usuario"].ToString()+" "+ dataTableResultado.Rows[0]["fecha_hora_inicio"].ToString()+" "+ dataTableResultado.Rows[0]["fecha_hora_final"].ToString();
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
                
            }
        }

        // POST: api/Rol
        public void Post([FromBody] Models.LoginUsuarios oLoginUsuarios)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string fechaHora = DateTime.Now.ToString();
                    
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO login_usuarios (id_usuario, fecha_hora_inicio) VALUES (" + oLoginUsuarios.Id_usuario + ", '" + fechaHora + "')";
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
        public void Put(int id, [FromBody] Models.LoginUsuarios oLoginUsuarios)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    string fechaHora = DateTime.Now.ToString();
                    
                    conector.Open();
                    SqlCommand comando = new SqlCommand();

                    comando.CommandText = "UPDATE login_usuarios SET fecha_hora_final = '" + fechaHora + "' WHERE id_login = " + id;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM login_usuarios WHERE id_login = " + id, conector);
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
