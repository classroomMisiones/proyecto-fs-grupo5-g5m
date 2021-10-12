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

    public class CuentasController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM cuentas", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_cuenta, Cvu, Id_usuario, Id_estado_cuenta FROM cuentas WHERE Id_cuenta = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                //return dataTableResultado.Rows[0]["Cvu"].ToString()+" "+ dataTableResultado.Rows[0]["Id_usuario"].ToString() + " " + dataTableResultado.Rows[0]["Id_estado_cuenta"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok(dataTableResultado);
        }

        // POST: api/Rol
        public string Post([FromBody] Models.Cuentas oCuentas)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string CVU_cuenta = "00000050";
                        string ID = oCuentas.Id_usuario.ToString();
                        for (int i = 0; i < (14-ID.Length); i++ ) {
                            CVU_cuenta += "0";
                        }
                    CVU_cuenta += ID;

                        oCuentas.Id_usuario.ToString();
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO cuentas (Cvu, Id_usuario, Id_estado_cuenta) VALUES ('" + CVU_cuenta + "', " + oCuentas.Id_usuario + ", " + oCuentas.Id_estado_cuenta + ")";
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
        public string Put(int id, [FromBody] Models.Cuentas oCuentas)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE cuentas SET Cvu = '" + oCuentas.Cvu + "', Id_usuario = " + oCuentas.Id_usuario + ", Id_estado_cuenta = " + oCuentas.Id_estado_cuenta + "  WHERE Id_cuenta = " + id;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM cuentas WHERE Id_cuenta = " + id, conector);
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
