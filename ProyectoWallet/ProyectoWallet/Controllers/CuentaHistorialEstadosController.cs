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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_historia_cuenta, Id_usuario, Id_cuenta, Id_estado_cuenta, Fecha_hora FROM cuentas_historial_estado WHERE Id_historia_cuenta = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                //return dataTableResultado;
               // return dataTableResultado.Rows[0]["Id_usuario"].ToString() + " " + dataTableResultado.Rows[0]["Id_cuenta"].ToString() + " " + dataTableResultado.Rows[0]["Id_estado_cuenta"].ToString() + " " + dataTableResultado.Rows[0]["Fecha_hora"].ToString() ;
            }
            catch (Exception)
            {
                //return "No se pudo realizar la operacion, Numero de Indice Erroneo";
            }
            return Ok(dataTableResultado);
        }

        // POST: api/Rol
        public string Post([FromBody] Models.CuentasHistorialEstado oCuentasHistorialEstado)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string fechaHora = DateTime.Now.ToString();
                    

                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO cuentas_historial_estado (Fecha_hora, Id_estado_cuenta, Id_cuenta, Id_usuario) VALUES ('" +fechaHora + "', " + oCuentasHistorialEstado.Id_estado_cuenta + ", " + oCuentasHistorialEstado.Id_cuenta + ", " + oCuentasHistorialEstado.Id_usuario + ")";
                    //comando.CommandText = "INSERT INTO cuentas_historial_estado (fecha_hora, id_estado_cuenta, id_cuenta, id_usuario) VALUES ('" + fechaHora + "', " + oCuentasHistorialEstado.Id_estado_cuenta + ", , " + oCuentasHistorialEstado.Id_cuenta + ", , " + oCuentasHistorialEstado.Id_usuario + ")";
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
        public string Put(int id, [FromBody] Models.CuentasHistorialEstado oCuentasHistorialEstado)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string fechaHora = DateTime.Now.ToString();
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE cuentas_historial_estado SET Fecha_hora = '" + fechaHora + "', Id_estado_cuenta =" + oCuentasHistorialEstado.Id_estado_cuenta + ", Id_cuenta = " + oCuentasHistorialEstado.Id_cuenta + ",  Id_usuario = " + oCuentasHistorialEstado.Id_usuario + " WHERE Id_historia_cuenta = " + id;
                    comando.Connection = conector;//
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
                    SqlCommand comando = new SqlCommand("DELETE FROM cuentas_historial_estado WHERE Id_historia_cuenta = " + id, conector);
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
