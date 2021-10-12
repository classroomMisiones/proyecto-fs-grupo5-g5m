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
    public class TransaccionesCuentaController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM transacciones_cuenta", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_transaccion, Id_usuario, Fecha, Hora, Id_tipo_transaccion, Id_cuenta_origen, Id_moneda_origen, Monto_origen, Id_cuenta_destino, Id_moneda_destino, Monto_destino FROM transacciones_cuenta WHERE Id_transaccion = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                //return dataTableResultado;
                //return dataTableResultado.Rows[0]["Id_transaccion"].ToString() + " " + dataTableResultado.Rows[0]["Fecha"].ToString() + " "+ dataTableResultado.Rows[0]["Hora"].ToString() + " " +
                    //dataTableResultado.Rows[0]["Id_tipo_transaccion"].ToString() + " " + dataTableResultado.Rows[0]["Id_cuenta_origen"].ToString() + " " + dataTableResultado.Rows[0]["Id_moneda_origen"].ToString() + " " +
                   // dataTableResultado.Rows[0]["Monto_origen"].ToString() + " " + dataTableResultado.Rows[0]["Id_cuenta_destino"].ToString() + " " +dataTableResultado.Rows[0]["Id_moneda_destino"].ToString() + " " +
                   // dataTableResultado.Rows[0]["Monto_destino"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok(dataTableResultado);
        }

        // POST: api/Rol
        public string Post([FromBody] Models.TransaccionesCuenta oTransaccionesCuenta)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    
                    comando.CommandText = "INSERT INTO transacciones_cuenta (Id_usuario, Fecha, Hora, Id_tipo_transaccion, Id_cuenta_origen, Id_moneda_origen, Monto_origen, Id_cuenta_destino, Id_moneda_destino, Monto_destino)  VALUES (" + oTransaccionesCuenta.Id_usuario+ ", '" +fecha + "', '" + hora + "', " + oTransaccionesCuenta.Id_tipo_transaccion + ", " + oTransaccionesCuenta.Id_cuenta_origen + ", " + oTransaccionesCuenta.Id_moneda_origen + ", " + oTransaccionesCuenta.Monto_origen.ToString().Replace(",", ".") + ", " + oTransaccionesCuenta.Id_cuenta_destino + ", " + oTransaccionesCuenta.Id_moneda_destino + ", " + oTransaccionesCuenta.Monto_destino.ToString().Replace(",", ".") + ")";
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
        public string Put(int id, [FromBody] Models.TransaccionesCuenta oTransaccionesCuenta)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE transacciones_cuenta SET Id_cuenta_origen = " + oTransaccionesCuenta.Id_cuenta_origen + ", Id_moneda_origen = " + oTransaccionesCuenta.Id_moneda_origen + ", Monto_origen = " + oTransaccionesCuenta.Monto_origen.ToString().Replace(",", ".") + ", Id_cuenta_destino =  " + oTransaccionesCuenta.Id_cuenta_destino + ", Id_moneda_destino = " + oTransaccionesCuenta.Id_moneda_destino + ", Monto_destino = " + oTransaccionesCuenta.Monto_destino.ToString().Replace(",", ".") + " WHERE Id_transaccion = " + id;   
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
                    SqlCommand comando = new SqlCommand("DELETE FROM transacciones_cuenta WHERE Id_transaccion = " + id, conector);
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
