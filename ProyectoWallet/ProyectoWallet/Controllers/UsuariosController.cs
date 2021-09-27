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
    //[EnableCors(origins: "http//localhost:4200", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["kepuaBDConexion"].ConnectionString;

        // GET: api/Usuario
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            try 
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM usuarios", conector);
                    adaptador.Fill(dt);
                }
                return Ok(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError(e);
            }
        }


        // GET: api/Usuario/5
        public DataTable Get(int id)
        {
            try
            { 
                DataTable dt = new DataTable();
               using (SqlConnection conector = new SqlConnection(mi_conexion))
               {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT id_usuario, nombre, apellido, dni_numero, direccion, nro_direccion, piso_departamento, fecha_clave, nombre_de_usuario FROM usuarios WHERE id_usuario = " + id, conector);
                    
                    //SqlCommand comando = new SqlCommand("SELECT nombre FROM usuarios WHERE id_usuario = " + id, conector);
                    adaptador.Fill(dt);
                    //nombre = comando.ExecuteScalar().ToString();
               }
                return dt;
                //return nombre;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // POST: api/Usuario
        public void Post([FromBody] Models.Usuario oUsuario)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            try 
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                 
                        conector.Open();
                        SqlCommand comando = new SqlCommand();
                        comando.CommandText = "INSERT INTO usuarios (nombre, apellido, id_email, id_rol, clave, fecha_clave,nombre_de_usuario ) VALUES ('" + oUsuario.Nombre + "','" + oUsuario.Apellido + "'," + oUsuario.Id_email + ", " + oUsuario.Id_rol + " ,'" + oUsuario.Clave + "', '" + fecha + "', '" + oUsuario.Nombre.Substring(0, 1) + "." + oUsuario.Apellido + "')";
                        comando.Connection = conector;
                        comando.ExecuteNonQuery();
                 
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            
        }


        // PUT: api/Usuario/5
        public void Put (int id, [FromBody] Models.Usuario oUsuario)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE usuarios SET nombre = '" + oUsuario.Nombre + "', apellido = '" + oUsuario.Apellido + "', dni_numero = " + oUsuario.Dni_numero + ", id_tipo_dni = " + oUsuario.Id_tipo_dni + ", direccion = '" + oUsuario.Direccion + "', nro_direccion = " + oUsuario.Nro_direccion + ", piso_departamento = '" + oUsuario.Piso_departamento + "', id_email = " + oUsuario.Id_email + " , id_telefono = " + oUsuario.Id_telefono + " ,  id_pais = " + oUsuario.Id_pais + " , id_provincia = " + oUsuario.Id_provincia + " ,id_localidad = " + oUsuario.Id_localidad + " , id_estado_cuenta = " + oUsuario.Id_estado_cuenta + " , id_rol = " + oUsuario.Id_rol + ", clave = '" + oUsuario.Clave + "', fecha_clave = '" + fecha + "', nombre_de_usuario = '" + oUsuario.Nombre_de_usuario + "'  WHERE id_usuario = " + id;

                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                    //comando.BeginExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            
        }

        public void Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try 
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand("DELETE FROM usuarios WHERE id_usuario = " + id, conector);
                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }
    }
}