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
        //Son el estado de registro y el tipo de mensaje que devolvera
        private bool registrado;
        private string mensaje;
        private DataTable datos = new DataTable();

        //Usado para devolver el tipo de peticion con la vista a la vez
        public ActionResult RegistrarAlquiler() { 
            return View();
        }
        public ActionResult listaAlquileres()
        {
            return View();
        }
        public ActionResult filtrarVentas()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarAlquiler(Alquileres alquiler)
        {
            

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
            

            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                 
                cn.Open();
                //Se ejecuta una sentencia SELECT par poder buscar los alquileres por Identificacion
                SqlDataAdapter sqlAD = new SqlDataAdapter("SELECT c.Identificacion, c.Nombres, j.nombre AS juegoRentado, a.Fecha FROM clientes c INNER JOIN alquileres a ON c.Identificacion = a.IdCliente INNER JOIN juegos j ON a.IdJuego = j.Id WHERE a.IdJuego IS NOT NULL", cn);

                sqlAD.Fill(datos);


            }

            return View(datos);
        }


        [HttpPost]
        public ActionResult filtrarVentas(string datoBuscar)
        {
            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                
                string fechaInicio = datoBuscar;
                //se agrega un dia de mas para poder dar bien los parametros a la hora de la consulta
                string fechaFin = DateTime.Parse(datoBuscar).AddDays(1).ToString("yyyy-MM-dd");


                string busquedaSQL = string.Format("SELECT j.Nombre AS juego, c.Nombres AS nombre_cliente, c.Identificacion, convert(date, a.Fecha) as Fecha_Alquiler FROM alquileres a INNER JOIN juegos j ON a.IdJuego = j.Id INNER JOIN clientes c ON a.IdCliente = c.Identificacion WHERE a.Fecha >= '{0}' AND a.Fecha < '{1}'", fechaInicio, fechaFin);
                cn.Open();
                SqlDataAdapter sqlAD = new SqlDataAdapter(busquedaSQL, cn);


                sqlAD.Fill(datos);
            }
            return View(datos);
        }

    }
}