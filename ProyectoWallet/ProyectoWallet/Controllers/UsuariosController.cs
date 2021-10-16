
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoWallet.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["kepuaBDConexion"].ConnectionString;

        [HttpGet]
        // GET: api/Usuario
        public IHttpActionResult Get()
        {
            DataTable dataTableResultado = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM usuarios", conector);
                    adaptador.Fill(dataTableResultado);
                }
                //return Ok(dataTableResultado);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_usuario, Nombre, Apellido, Dni_numero, Direccion, Nro_direccion, Piso_departamento, Fecha_clave, Nombre_de_usuario FROM usuarios WHERE Id_usuario = " + id, conector);

                    //SqlCommand comando = new SqlCommand("SELECT nombre FROM usuarios WHERE id_usuario = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                    //nombre = comando.ExecuteScalar().ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok(dataTableResultado);
        }

        // POST: api/Usuario
        public string Post([FromBody] Models.Usuario oUsuario)
        {
            try
            {
                // otra forma de encriptacion string Key = Models.Encrypt.GetSHA256(oUsuario.Clave);
                // tomo solo la fecha n el formato dia-mes-año
                string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    //Encripto la clave con el metodo HashSalt
                    comando.CommandText = "INSERT INTO usuarios (Nombre, Apellido, Id_email, Id_rol, Clave, fecha_Clave, Nombre_de_usuario ) VALUES ('" + oUsuario.Nombre + "','" + oUsuario.Apellido + "'," + oUsuario.Id_email + ", " + oUsuario.Id_rol + " ,'" + Crypto.HashPassword(oUsuario.Clave) + "', '" + fecha + "', '" + oUsuario.Nombre.Substring(0, 1) + "." + oUsuario.Apellido + "')";
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

        // PUT: api/Usuario/5
        public string Put(int id, [FromBody] Models.Usuario oUsuario)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();

                    // busco la clave en el registro por el id y creo una tabla con el resultado
                    DataTable dataTableResultado = new DataTable();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT clave FROM usuarios WHERE Id_usuario = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                    //verifico que exista el id buscado
                    if (dataTableResultado.Rows[0]["Clave"].ToString() != null)
                    {

                        //Verifico si las claves son iguales
                        // otra forma de verificascion - if (dataTableResultado.Rows[0]["clave"].ToString() == Models.Encrypt.GetSHA256(oUsuario.Clave))
                        if (Crypto.VerifyHashedPassword(dataTableResultado.Rows[0]["Clave"].ToString(), oUsuario.Clave))
                        {
                            // Claves iguales, no se graba nuevamente
                            comando.CommandText = "UPDATE usuarios SET Nombre = '" + oUsuario.Nombre + "', Apellido = '" + oUsuario.Apellido + "', Dni_numero = " + oUsuario.Dni_numero + ", Id_tipo_dni = " + oUsuario.Id_tipo_dni + ", Direccion = '" + oUsuario.Direccion + "', Nro_direccion = " + oUsuario.Nro_direccion + ", Piso_departamento = '" + oUsuario.Piso_departamento + "', Id_email = " + oUsuario.Id_email + " , Id_telefono = " + oUsuario.Id_telefono + " ,  Id_pais = " + oUsuario.Id_pais + " , Id_provincia = " + oUsuario.Id_provincia + " ,Id_localidad = " + oUsuario.Id_localidad + " , Id_estado_cuenta = " + oUsuario.Id_estado_cuenta + " , Id_rol = " + oUsuario.Id_rol + ",  Nombre_de_usuario = '" + oUsuario.Nombre_de_usuario + "'  WHERE Id_usuario = " + id;
                        }
                        else
                        {
                            // Clave nueva, se encripta y graba
                            comando.CommandText = "UPDATE usuarios SET Nombre = '" + oUsuario.Nombre + "', Apellido = '" + oUsuario.Apellido + "', Dni_numero = " + oUsuario.Dni_numero + ", Id_tipo_dni = " + oUsuario.Id_tipo_dni + ", Direccion = '" + oUsuario.Direccion + "', Nro_direccion = " + oUsuario.Nro_direccion + ", Piso_departamento = '" + oUsuario.Piso_departamento + "', Id_email = " + oUsuario.Id_email + " , Id_telefono = " + oUsuario.Id_telefono + " ,  Id_pais = " + oUsuario.Id_pais + " , Id_provincia = " + oUsuario.Id_provincia + " ,Id_localidad = " + oUsuario.Id_localidad + " , Id_estado_cuenta = " + oUsuario.Id_estado_cuenta + " , Id_rol = " + oUsuario.Id_rol + ", Clave = '" + Crypto.HashPassword(oUsuario.Clave) + "', Fecha_clave = '" + fecha + "', Nombre_de_usuario = '" + oUsuario.Nombre_de_usuario + "'  WHERE Id_usuario = " + id;
                        }

                        comando.Connection = conector;
                        comando.ExecuteNonQuery();
                        //comando.BeginExecuteNonQuery();
                    }
                }
                return "OPERACION DE ACUALIZACION EXITOSA";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "NO SE PUDO COMPLETAR LA OPERACION DE ACUALIZACION";
            }
        }

        // DELETE: api/Usuario/5
        public string Delete(int id)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand("DELETE FROM usuarios WHERE Id_usuario = " + id, conector);
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

        //************************************************
        //*************** TODOS NUEVOS *******************
        //************************************************
        internal string GetLoginUsuarios([FromBody] Models.LoginRequest oLogin)
        {
            DataTable tablaEmail = new DataTable();
            DataTable tablaUsuario = new DataTable();
            DataTable tablaRol = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    // Hago un select de la tabla email y obtengo el Id usuario
                    SqlDataAdapter adaptadorEmail = new SqlDataAdapter("SELECT * FROM email WHERE Mail = '" + oLogin.Mail + "'", conector);
                    adaptadorEmail.Fill(tablaEmail);
                    // Hago un select de la tabla usuario y obtengo la clave
                    SqlDataAdapter adaptadorUsuario = new SqlDataAdapter("SELECT Clave, Id_rol FROM usuarios WHERE Id_usuario = '" + tablaEmail.Rows[0]["Id_usuario"] + "'", conector);
                    adaptadorUsuario.Fill(tablaUsuario);
                    // Hago un select de la tabla rol y obtengo el rol del usuario
                    SqlDataAdapter adaptadorRol = new SqlDataAdapter("SELECT Descripcion FROM rol WHERE Id_rol = '" + tablaUsuario.Rows[0]["Id_rol"] + "'", conector);
                    adaptadorRol.Fill(tablaRol);

                    //SqlDataAdapter adaptadorEmailUsuario = new SqlDataAdapter("SELECT email.Mail, usuarios.Clave FROM email INNER JOIN usuarios ON email.Id_usuario =  '" +tablaEmail.Rows[0]["Id_usuario"].ToString()+"' && usuarios.Id_usuario = '"+tablaEmail.Rows[0]["Id_usuario"].ToString()+"' ", conector);
                    //adaptadorEmailUsuario.Fill(tablaJOIN);
                    //(oLogin.Mail == tablaJOIN.Rows[0]["Mail"].ToString() && Crypto.VerifyHashedPassword(tablaJOIN.Rows[0]["Clave"].ToString(), oLogin.Clave))

                    if (oLogin.Mail == tablaEmail.Rows[0]["Mail"].ToString() && Crypto.VerifyHashedPassword(tablaUsuario.Rows[0]["Clave"].ToString(), oLogin.Clave))
                    {
                        return tablaRol.Rows[0]["Descripcion"].ToString();
                    }
                    else
                    {
                        return "Datos no encontrados!";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Datos no encontrados!";
            }
        }


        internal int GetLoginID([FromBody] Models.LoginRequest oLogin)
        {
            DataTable tablaEmail = new DataTable();
            DataTable tablaUsuario = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    // Hago un select de la tabla email y obtengo el Id usuario
                    SqlDataAdapter adaptadorEmail = new SqlDataAdapter("SELECT * FROM email WHERE Mail = '" + oLogin.Mail + "'", conector);
                    adaptadorEmail.Fill(tablaEmail);
                    // Hago un select de la tabla usuario y obtengo la clave
                    SqlDataAdapter adaptadorUsuario = new SqlDataAdapter("SELECT Clave, Id_rol FROM usuarios WHERE Id_usuario = '" + tablaEmail.Rows[0]["Id_usuario"] + "'", conector);
                    adaptadorUsuario.Fill(tablaUsuario);

                    if (oLogin.Mail == tablaEmail.Rows[0]["Mail"].ToString() && Crypto.VerifyHashedPassword(tablaUsuario.Rows[0]["Clave"].ToString(), oLogin.Clave))
                    {
                        return (int)tablaEmail.Rows[0]["Id_usuario"];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

    }
}