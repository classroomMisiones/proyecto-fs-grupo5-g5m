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
            catch (Exception)
            {
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT id_transaccion, id_usuario, fecha, Hora, id_tipo_transaccion, id_cuenta_origen, id_moneda_origen, monto_origen, id_cuenta_destino, id_moneda_destino, monto_destino, id_tarjeta FROM transacciones_cuenta WHERE id_transaccion = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                //return dataTableResultado;
                return dataTableResultado.Rows[0]["id_transaccion"].ToString() + " " + dataTableResultado.Rows[0]["fecha"].ToString() + " "+ dataTableResultado.Rows[0]["hora"].ToString() + " " +
                    dataTableResultado.Rows[0]["id_tipo_transaccion"].ToString() + " " + dataTableResultado.Rows[0]["id_cuenta_origen"].ToString() + " " + dataTableResultado.Rows[0]["id_moneda_origen"].ToString() + " " +
                    dataTableResultado.Rows[0]["monto_origen"].ToString() + " " + dataTableResultado.Rows[0]["id_cuenta_destino"].ToString() + " " +dataTableResultado.Rows[0]["id_moneda_destino"].ToString() + " " +
                    dataTableResultado.Rows[0]["monto_destino"].ToString();
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
                //return null;
            }
        }

        // POST: api/Rol
        public void Post([FromBody] Models.TransaccionesCuenta oTransaccionesCuenta)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    
                    comando.CommandText = "INSERT INTO transacciones_cuenta (id_usuario, fecha, hora, id_tipo_transaccion, id_cuenta_origen, id_moneda_origen, monto_origen, id_cuenta_destino, id_moneda_destino, monto_destino) " +
                                            "VALUES (" + oTransaccionesCuenta.Id_usuario+ ", '" +fecha + "', '" + hora + "', " + oTransaccionesCuenta.Id_tipo_transaccion + ", " + oTransaccionesCuenta.Id_cuenta_origen + ", " + oTransaccionesCuenta.Id_moneda_origen + ", " + oTransaccionesCuenta.Monto_origen + ", " + oTransaccionesCuenta.Id_cuenta_destino + ", " + oTransaccionesCuenta.Id_moneda_destino + ", " + oTransaccionesCuenta.Monto_destino + ")";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.TransaccionesCuenta oTransaccionesCuenta)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    //comando.CommandText = "UPDATE transacciones_cuenta SET nombre = '" + oTransaccionesCuenta.Nombre + "',  id_pais = " + oTransaccionesCuenta.Id_pais + " WHERE id_transaccion = " + id;
                    comando.Connection = conector;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM transacciones_cuenta WHERE id_transaccion = " + id, conector);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
