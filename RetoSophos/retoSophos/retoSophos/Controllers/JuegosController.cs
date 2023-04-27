using retoSophos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace retoSophos.Controllers
{
    public class JuegosController : Controller
    {
        //Son el estado de registro y el tipo de mensaje que devolvera
        private bool registrado;
        private string mensaje;
        DataTable data = new DataTable();
        public ActionResult CrearJuego()
        {
            return View();
        }

        public ActionResult EditarPrecio()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CrearJuego(Juegos juego)
        {
            
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
                return RedirectToAction("Listarjuegos", "Juegos");
            }
            else
            {
                ViewData["Mensaje"] = "El Juego ya Existe";
                return View();
            }
        }


        [HttpGet]
        public ActionResult Listarjuegos()
        {
            
            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                //
                cn.Open();
                SqlDataAdapter sqlAD = new SqlDataAdapter("select * from Juegos", cn);

                sqlAD.Fill(data);

            }
            return View(data);
        }



        [HttpPost]
        public ActionResult Buscar(string datoBuscar) 
        {

            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                
                string busquedaSQL = string.Format("select * from Juegos where Director + Protagonistas + ProductorMarca + FechaLanzamiento like '%{0}%' order by Nombre asc", datoBuscar);
                cn.Open();
                SqlDataAdapter sqlAD = new SqlDataAdapter(busquedaSQL,cn);

                sqlAD.Fill(data);


            }
            return View(data);
        }


        [HttpPut]
        public ActionResult EditarPrecio(Juegos juego)
        {

            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                //se agregan los valores a el proceso sp_RegistrarUsuario
                SqlCommand cmd = new SqlCommand("sp_ActualizarPrecio", cn);
                cmd.Parameters.AddWithValue("NombreJuego", juego.Nombre);
                cmd.Parameters.AddWithValue("PrecioNuevo", juego.Precio);
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
                return RedirectToAction("Listarjuegos", "Juegos");
            }
            else
            {
                ViewData["Mensaje"] = mensaje;
                return View();
            }
        }
    }

}
