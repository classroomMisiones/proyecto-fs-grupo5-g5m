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
    public class TarjetasController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM tarjetas", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT numero_tarjeta, Fecha_vencimiento, id_usuario FROM tarjetas WHERE id_tarjeta = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                //return dataTableResultado;
                return dataTableResultado.Rows[0]["numero_tarjeta"].ToString();
            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
                //return null;
            }
        }

        // POST: api/Rol
        public void Post([FromBody] Models.Tarjetas oTarjetas)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO tarjetas (numero_tarjeta, fecha_vencimiento, id_usuario) VALUES ('" + oTarjetas.Numero_tarjeta + "','" + oTarjetas.Fecha_vencimiento + "'," + oTarjetas.Id_usuario + " )";
                    comando.Connection = conector;
                    
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.Tarjetas oTarjetas)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE tarjetas SET numero_tarjeta = '" + oTarjetas.Numero_tarjeta + "',  fecha_vencimiento = '" + oTarjetas.Fecha_vencimiento + "' , id_usuario = "+ oTarjetas.Id_usuario +" WHERE id_tarjeta = " + id;
                    comando.Connection = conector;
                    //comando.BeginExecuteNonQuery();
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
                    SqlCommand comando = new SqlCommand("DELETE FROM tarjetas WHERE id_tarjeta = " + id, conector);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
