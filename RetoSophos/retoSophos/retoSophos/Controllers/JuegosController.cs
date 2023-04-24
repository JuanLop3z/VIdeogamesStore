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
    public class JuegosController : Controller
    {
        
        public ActionResult CrearJuego()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CrearJuego(Juegos juego)
        {
            //Son el estado de registro y el tipo de mensaje que devolvera
            bool registrado;
            string mensaje;




            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                //se agregan los valores a el proceso sp_CrearJuego
                SqlCommand cmd = new SqlCommand("sp_CrearJuego", cn);
                cmd.Parameters.AddWithValue("Nombre", juego.Nombre);
                cmd.Parameters.AddWithValue("Precio", juego.Precio);
                cmd.Parameters.AddWithValue("Plataforma", juego.Plataforma);
                cmd.Parameters.AddWithValue("Director", juego.Director);
                cmd.Parameters.AddWithValue("Protagonistas", juego.Protagonistas);
                cmd.Parameters.AddWithValue("ProductorMarca", juego.ProductorMarca);
                cmd.Parameters.AddWithValue("FechaLanzamiento", juego.FechaLanzamiento);
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
                ViewData["Mensaje"] = "El Juego ya Existe";
                return View();
            }
        }
    }
}