using retoSophos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace retoSophos.Controllers
{
    public class ClientesController : Controller
    {
        //Son el estado de registro y el tipo de mensaje que devolvera
        private bool registrado;
        private string mensaje;
        private DataTable data = new DataTable();


        public ActionResult RegistrarCliente()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarCliente(Clientes cliente)
        {

            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                //se agregan los valores a el proceso sp_CrearClientes
                SqlCommand cmd = new SqlCommand("sp_CrearClientes", cn);
                cmd.Parameters.AddWithValue("Identificacion", cliente.Identificacion);
                cmd.Parameters.AddWithValue("Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("Edad", cliente.Edad);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();


            }

            ViewData["Mensajes"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Cuenta");
            }
            else
            {
                ViewData["Mensaje"] = "El cliente ya existe";
                return View();
            }

        }


        [HttpGet]
        public ActionResult listarClientes()
        {
            
            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {

                cn.Open();
                SqlDataAdapter sqlAD = new SqlDataAdapter("select * from Clientes", cn);

                sqlAD.Fill(data);


            }
            return View(data);
        }


    }
}
