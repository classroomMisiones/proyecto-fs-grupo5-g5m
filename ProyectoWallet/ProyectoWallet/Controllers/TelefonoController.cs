﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoWallet.Controllers
{
    public class TelefonoController : ApiController
    {
        public string mi_conexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dataTableResultado = new DataTable();
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM telefono", conector);
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
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT numero_telefono FROM telefono WHERE id_telefono = " + id, conector);
                    adaptador.Fill(dataTableResultado);
                }
                return dataTableResultado.Rows[0]["numero_telefono"].ToString();

            }
            catch (Exception)
            {
                return "No se pudo realizar la operacion, Numero de Indice Erroneo";
            }

        }

        // POST: api/Rol
        public void Post([FromBody] Models.Telefono oTelefono)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "INSERT INTO telefono (numero_telefono, id_usuario) VALUES ('" + oTelefono.Numero_telefono + "', " + oTelefono.Id_usuario + ")";
                    comando.Connection = conector;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody] Models.Telefono oTelefono)
        {
            try
            {
                using (SqlConnection conector = new SqlConnection(mi_conexion))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "UPDATE telefono SET numero_telefono = '" + oTelefono.Numero_telefono + "', id_usuario = " + oTelefono.Id_usuario + " WHERE id_telefono = " + id;
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
                    SqlCommand comando = new SqlCommand("DELETE FROM telefono WHERE id_telefono = " + id, conector);
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