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
    public class AlquileresController : Controller
    {
        public ActionResult RegistrarAlquiler() { 
            return View();
        }

        public ActionResult listaAlquileres()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarAlquiler(Alquileres alquiler)
        {
            //Son el estado de registro y el tipo de mensaje que devolvera
            bool registrado;
            string mensaje;




            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                //se agregan los valores a el proceso sp_RegistrarAlquiler
                SqlCommand cmd = new SqlCommand("sp_RegistrarAlquiler", cn);
                cmd.Parameters.AddWithValue("IdCliente", alquiler.IdCliente);
                cmd.Parameters.AddWithValue("NombreJuego", alquiler.NombreJuego);
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
                return RedirectToAction("RegistrarAlquiler", "Alquileres");
            }
            else
            {
                ViewData["Mensaje"] = "El juego no existe";
                return View();
            }
        }


        [HttpGet]
        public ActionResult listaAlquileres(Alquileres alquiler)
        {
            DataTable data = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                //
                cn.Open();
                SqlDataAdapter sqlAD = new SqlDataAdapter("SELECT c.Identificacion, c.Nombres, j.nombre AS juegoRentado, a.Fecha FROM clientes c INNER JOIN alquileres a ON c.Identificacion = a.IdCliente INNER JOIN juegos j ON a.IdJuego = j.Id WHERE a.IdJuego IS NOT NULL", cn);

                sqlAD.Fill(data);


            }


            return View(data);
        }
    }
}