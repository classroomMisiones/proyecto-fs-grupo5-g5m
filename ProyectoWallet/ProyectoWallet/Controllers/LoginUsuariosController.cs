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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return Ok(dataTableResultado);
            }
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_login, Id_usuario, Fecha_hora_inicio, Fecha_hora_final FROM login_usuarios WHERE Id_login = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
               // return dataTableResultado.Rows[0]["Id_usuario"].ToString()+" "+ dataTableResultado.Rows[0]["Fecha_hora_inicio"].ToString()+" "+ dataTableResultado.Rows[0]["Fecha_hora_final"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok(dataTableResultado);
        }

        // POST: api/Rol
        public string Post([FromBody] Models.LoginRequest oLogin)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    if (oLogin == null)
                        throw new HttpResponseException(HttpStatusCode.BadRequest);

                    // Llamo a la funcion del UsuarioController y verifico los datos
                    var oGetLoginID = new UsuariosController();
                    // Obtengo la respuesta en un string
                    var respuestaID = oGetLoginID.GetLoginID(oLogin);
                    // Verifico y genero el tocken

                    string fechaHora = DateTime.Now.ToString();
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO login_usuarios (Id_usuario, Fecha_hora_inicio) VALUES (" + respuestaID + ", '" + fechaHora + "')";
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
        public string Put(int id, [FromBody] Models.LoginUsuarios oLoginUsuarios)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    DataTable dataTableResultado = new DataTable();
                    conector.Open();
                    
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_login from login_usuarios WHERE Id_usuario = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                    var registro = dataTableResultado.Rows.Count;
                    var IdLogin = dataTableResultado.Rows[registro - 1]["Id_usuario"];


                    string fechaHora = DateTime.Now.ToString();
                                       
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE login_usuarios SET Fecha_hora_final = '" + fechaHora + "' WHERE Id_login = " + IdLogin;
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                    return "OPERACION DE ACUALIZACION EXITOSA";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "NO SE PUDO COMPLETAR LA OPERACION DE ACUALIZACION";
                }
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
                    SqlCommand comando = new SqlCommand("DELETE FROM login_usuarios WHERE Id_login = " + id, conector);
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
