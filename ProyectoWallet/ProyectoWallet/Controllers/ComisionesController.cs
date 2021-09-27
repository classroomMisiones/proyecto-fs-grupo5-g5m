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
    [EnableCors(origins: "http//localhost:4200", headers: "*", methods: "*")]
    public class ComisionesController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM comisiones", conector);
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

                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT id_transaccion, id_moneda, porcentaje_comision, monto_comision, fecha FROM comisiones WHERE id_comision = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                return dataTableResultado.Rows[0]["id_transaccion"].ToString();

            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
            }

        }

        // POST: api/Rol
        public void Post([FromBody] Models.Comisiones oComisiones)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO comisiones (id_transaccion, id_moneda, porcentaje_comision, monto_comision, fecha) VALUES (" + oComisiones.Id_transaccion + ","+ oComisiones.Id_moneda +","+ oComisiones.Porcentaje_comision +" ,"+ oComisiones.Monto_comision +", '" + oComisiones.Fecha + "')";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.Comisiones oComisiones)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE comisiones SET id_transaccion = " + oComisiones.Id_transaccion + ", id_moneda = " + oComisiones.Id_moneda + ", porcentaje_comision = " + oComisiones.Porcentaje_comision + ", monto_comision = " + oComisiones.Monto_comision + ", fecha = '"+ oComisiones.Fecha + "'  WHERE id_comision = " + id;
                    //;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM comisiones WHERE id_comision = " + id, conector);
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
