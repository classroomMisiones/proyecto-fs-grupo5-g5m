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
    public class SaldoCuentaController : ApiController
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM saldo_cuenta", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_saldo, Id_usuario, Id_moneda, Saldo, Fecha, Hora FROM saldo_cuenta WHERE Id_usuario = " + id, conector);
                    adaptador.Fill(dataTableResultado);

                }
                //return dataTableResultado;
                //return dataTableResultado.Rows[0]["id_usuario"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok(dataTableResultado);
        }

       

        // POST: api/Rol
        public string Post([FromBody] Models.SaldoCuenta oSaldoCuenta)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO saldo_cuenta (Id_usuario, Id_moneda, Saldo, Fecha, Hora) VALUES (" + oSaldoCuenta.Id_usuario + ", " + oSaldoCuenta.Id_moneda + ", " + oSaldoCuenta.Saldo.ToString().Replace(",", ".") + ", '"+ fecha + "', '" + hora + "')";
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
        public string Put(int id, [FromBody] Models.SaldoCuenta oSaldoCuenta)
        {
            using (SqlConnection conector = new SqlConnection(mi_conexion))
            {
                try
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    string hora = DateTime.Now.ToString("hh:mm:ss");

                    conector.Open();
                    SqlCommand comando = new SqlCommand();

                    comando.CommandText = "UPDATE saldo_cuenta SET Id_usuario = " + oSaldoCuenta.Id_usuario + ", Id_moneda = " + oSaldoCuenta.Id_moneda + ", Saldo = " + oSaldoCuenta.Saldo.ToString().Replace(",", ".") +
                        ", Fecha = '"+ fecha +"', Hora = '"+ hora +"' WHERE Id_saldo = " + id;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM saldo_cuenta WHERE Id_saldo = " + id, conector);
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
        // *********************************************
        // *********** GET POR TIPO DE MONEDA **********
        // *********************************************

        //[HttpGet]
        //// GET: api/Usuario/
        //public IHttpActionResult GetSaldoxMoneda(int id, [FromBody] Models.SaldoCuenta oSaldoCuenta)
        //{
        //    DataTable dataTableResultado = new DataTable();
        //    try
        //    {
        //        using (SqlConnection conector = new SqlConnection(mi_conexion))
        //        {
        //            conector.Open();
        //            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id_saldo, Saldo, Fecha, Hora FROM saldo_cuenta WHERE Id_usuario = '" +
        //                id + "' &&  Id_moneda = '" + oSaldoCuenta.Id_moneda + "' ", conector);
        //            adaptador.Fill(dataTableResultado);
        //        }
        //        return Ok(dataTableResultado);
        //        //return dataTableResultado;
        //        //return dataTableResultado.Rows[0]["id_usuario"].ToString();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return Ok(e.Message);
        //    }
        //    //return Ok(dataTableResultado);
        //}
    }
}
