using retoSophos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace retoSophos.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult RegistrarCliente()
        {
            return View();
        }



        [HttpPost]
        public ActionResult RegistrarCliente(Clientes cliente)
        {
            //Son el estado de registro y el tipo de mensaje que devolvera
            bool registrado;
            string mensaje;




            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                //se agregan los valores a el proceso sp_RegistrarUsuario
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


        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("RegistrarCliente");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("RegistrarCliente");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("RegistrarCliente");
            }
            catch
            {
                return View();
            }
        }
    }
}
