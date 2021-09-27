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
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCors(origins: "http//localhost:4200", headers: "*", methods: "*")]
    //[EnableCors(origins: "http//localhost:44344", headers: "*", methods: "*")]
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
                return Ok(dataTableResultado);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
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

                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT cvu, id_usuario, id_estado_cuenta FROM cuentas WHERE id_cuenta = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                return dataTableResultado.Rows[0]["cvu"].ToString()+" "+ dataTableResultado.Rows[0]["id_usuario"].ToString() + " " + dataTableResultado.Rows[0]["id_estado_cuenta"].ToString();

            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
            }

        }

        // POST: api/Rol
        public void Post([FromBody] Models.Cuentas oCuentas)
        {
            try
            {
                
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO cuentas (cvu, id_usuario, id_estado_cuenta) VALUES ('" + oCuentas.Cvu + "', " + oCuentas.Id_usuario + ", " + oCuentas.Id_estado_cuenta + ")";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.Cuentas oCuentas)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE cuentas SET cvu = '" + oCuentas.Cvu + "', id_usuario = " + oCuentas.Id_usuario + ", id_estado_cuenta = " + oCuentas.Id_estado_cuenta + "  WHERE id_cuenta = " + id;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM cuentas WHERE id_cuenta = " + id, conector);
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
