using retoSophos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace retoSophos.Controllers
{
    public class CuentaController : Controller
    {
        //Son el estado de registro y el tipo de mensaje que devolvera
        private bool registrado;
        private string mensaje;


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {

            if (usuario.Clave == usuario.ConfirmarClave)
            {
                usuario.Clave = cifrarClave(usuario.Clave);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }


            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                //se agregan los valores a el proceso sp_RegistrarUsuario
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.Parameters.AddWithValue("Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("Clave", usuario.Clave);
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
                ViewData["Mensajes"] = "El usuario ya existe";
                return View();
            }
        }


        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {

            usuario.Clave = cifrarClave(usuario.Clave);

            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("Clave", usuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                usuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());

            }


            if (usuario.IdUsuario != 0)
            {
                Session["usuario"] = usuario;
                return RedirectToAction("Principal", "Principal");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
        }


        public static string cifrarClave(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

    }

}

