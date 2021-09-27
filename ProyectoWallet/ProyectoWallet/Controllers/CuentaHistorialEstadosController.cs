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
    public class CuentaHistorialEstadosController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM cuentas_historial_estado", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT id_usuario, id_cuenta, id_estado_cuenta, fecha_hora FROM cuentas_historial_estado WHERE id_historia_cuenta = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                //return dataTableResultado;
                return dataTableResultado.Rows[0]["id_usuario"].ToString() + " " + dataTableResultado.Rows[0]["id_cuenta"].ToString() + " " + dataTableResultado.Rows[0]["id_estado_cuenta"].ToString() + " " + dataTableResultado.Rows[0]["fecha_hora"].ToString() ;
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";

            }
        }

        // POST: api/Rol
        public void Post([FromBody] Models.CuentasHistorialEstado oCuentasHistorialEstado)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string fechaHora = DateTime.Now.ToString();
                    

                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO cuentas_historial_estado (fecha_hora, id_estado_cuenta, id_cuenta, id_usuario) VALUES ('" +fechaHora + "', " + oCuentasHistorialEstado.Id_estado_cuenta + ", " + oCuentasHistorialEstado.Id_cuenta + ", " + oCuentasHistorialEstado.Id_usuario + ")";
                    //comando.CommandText = "INSERT INTO cuentas_historial_estado (fecha_hora, id_estado_cuenta, id_cuenta, id_usuario) VALUES ('" + fechaHora + "', " + oCuentasHistorialEstado.Id_estado_cuenta + ", , " + oCuentasHistorialEstado.Id_cuenta + ", , " + oCuentasHistorialEstado.Id_usuario + ")";
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
        public void Put(int id, [FromBody] Models.CuentasHistorialEstado oCuentasHistorialEstado)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    string fechaHora = DateTime.Now.ToString();

                    conector.Open();
                    SqlCommand comando = new SqlCommand();

                    comando.CommandText = "UPDATE cuentas_historial_estado SET fecha_hora = '" +fechaHora + "', id_estado_cuenta =" + oCuentasHistorialEstado.Id_estado_cuenta + ", id_cuenta = " + oCuentasHistorialEstado.Id_cuenta + ",  id_usuario = " + oCuentasHistorialEstado.Id_usuario + " WHERE id_historia_cuenta = " + id;
                    comando.Connection = conector;//

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
                    SqlCommand comando = new SqlCommand("DELETE FROM cuentas_historial_estado WHERE id_historia_cuenta = " + id, conector);
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
