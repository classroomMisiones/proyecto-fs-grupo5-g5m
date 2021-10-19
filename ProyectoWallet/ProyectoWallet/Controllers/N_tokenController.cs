using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoWallet.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class N_tokenController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["kepuaBDConexion"].ConnectionString;

        //// GET: api/N_token
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/N_token/5
        [HttpGet]
        public int Get(string cadena)
        {
            DataTable tablaUsuario = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    // Hago un select de la tabla usuario y obtengo el ID por el tocken
                    SqlDataAdapter adaptadorUsuario = new SqlDataAdapter("SELECT Id_usuario FROM usuarios WHERE N_token = '" + cadena +"' ", conector);
                    adaptadorUsuario.Fill(tablaUsuario);
                    // retorno el Id
                       return (int)tablaUsuario.Rows[0]["Id_usuario"];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        //// POST: api/N_token
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/Usuario/
        public void Put([FromBody] Models.N_Token oN_Token)
        {
            DataTable tablaEmail = new DataTable();
            DataTable tablaUsuario = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    //****************
                    // Hago un select de la tabla email y obtengo el Id usuario
                    SqlDataAdapter adaptadorEmail = new SqlDataAdapter("SELECT Mail, Id_usuario FROM email WHERE Mail = '" + oN_Token.Mail + "'", conector);
                    adaptadorEmail.Fill(tablaEmail);
                    var ultregistro = tablaEmail.Rows.Count;
                    if (ultregistro > 0 ) 
                    {
                        ultregistro--;
                    }

                    // Hago un select de la tabla usuario y obtengo la clave
                    SqlDataAdapter adaptadorUsuario = new SqlDataAdapter("SELECT Clave, Id_usuario FROM usuarios WHERE Id_usuario = '" + tablaEmail.Rows[ultregistro]["Id_usuario"] + "'", conector);
                    adaptadorUsuario.Fill(tablaUsuario);
                    // verifico que coincidan
                    if (oN_Token.Mail == tablaEmail.Rows[ultregistro]["Mail"].ToString() && Crypto.VerifyHashedPassword(tablaUsuario.Rows[0]["Clave"].ToString(), oN_Token.Clave))
                    {
                        //Grabo el nuevo Token
                        comando.CommandText = "UPDATE usuarios SET N_token = '" + oN_Token.N_token + "' WHERE Id_usuario = " + (int)tablaUsuario.Rows[0]["Id_usuario"];
                        comando.Connection = conector;
                        comando.ExecuteNonQuery();
                        //comando.BeginExecuteNonQuery();
                    }

                }
                //return "OPERACION DE ACUALIZACION EXITOSA";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //return "NO SE PUDO COMPLETAR LA OPERACION DE ACUALIZACION";
            }
        }

        //// DELETE: api/N_token/5
        //public void Delete(int id)
        //{
        //}

        // GET: api/N_token/5
        
    }
}
