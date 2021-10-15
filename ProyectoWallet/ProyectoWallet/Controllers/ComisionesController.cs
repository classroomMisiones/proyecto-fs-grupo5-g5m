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
            catch (Exception e)
            {
                Console.WriteLine(e);
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

                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_comision, Id_transaccion, Id_moneda, Porcentaje_comision, Monto_comision, Fecha FROM comisiones WHERE Id_comision = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                    //dataTableResultado.Rows[0]["Id_transaccion"].ToString()+" "+ dataTableResultado.Rows[0]["Id_moneda"].ToString() + " " + 
                    //dataTableResultado.Rows[0]["Porcentaje_comision"].ToString() + " " +dataTableResultado.Rows[0]["Monto_comision"].ToString() + " " + dataTableResultado.Rows[0]["Fecha"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok(dataTableResultado);
        }

        // POST: api/Rol
        public string Post([FromBody] Models.Comisiones oComisiones)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO comisiones (Id_transaccion, Id_moneda, Porcentaje_comision, Fecha , Monto_comision) VALUES (" + oComisiones.Id_transaccion + ","+ oComisiones.Id_moneda +","+ oComisiones.Porcentaje_comision.ToString().Replace(",", ".") + " , '" + fecha + "'," + oComisiones.Monto_comision.ToString().Replace(",", ".") + ")";
                    
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
        public string Put(int id, [FromBody] Models.Comisiones oComisiones)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE comisiones SET Id_transaccion = " + oComisiones.Id_transaccion + ", Id_moneda = " + oComisiones.Id_moneda + ", Fecha = '"+ fecha + "', Porcentaje_comision = " + oComisiones.Porcentaje_comision.ToString().Replace(",", ".") + ", Monto_comision= " + oComisiones.Monto_comision.ToString().Replace(",", ".") + "  WHERE Id_comision = " + id;
                    
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
                    SqlCommand comando = new SqlCommand("DELETE FROM comisiones WHERE Id_comision = " + id, conector);
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
