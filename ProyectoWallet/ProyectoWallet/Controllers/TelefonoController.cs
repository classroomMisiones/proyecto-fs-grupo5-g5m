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
    public class TelefonoController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM telefono", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_telefono, Numero_telefono, Id_usuario FROM telefono WHERE Id_telefono = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                //return dataTableResultado.Rows[0]["numero_telefono"].ToString() +" "+ dataTableResultado.Rows[0]["id_usuario"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok(dataTableResultado);
        }

        // POST: api/Rol
        public string Post([FromBody] Models.Telefono oTelefono)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO telefono (Numero_telefono, Id_usuario) VALUES ('" + oTelefono.Numero_telefono + "', " + oTelefono.Id_usuario + ")";
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
        public string Put(int id, [FromBody] Models.Telefono oTelefono)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE telefono SET Numero_telefono = '" + oTelefono.Numero_telefono + "', Id_usuario = " + oTelefono.Id_usuario + " WHERE Id_telefono = " + id;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM telefono WHERE Id_telefono = " + id, conector);
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
