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
    public class PrincipalController : Controller
    {
        //Modelo para hacer los dataTable y poder devolverlos en la vista
        private AlquileresView viewModel = new AlquileresView();


        //Vista Principal y menu de Opciones
        [HttpGet]
        public ActionResult Principal() 
        {
            
            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {
                //Sentencia usada para contar los numeros de ventas por IdCliente
                string clientesql = ("SELECT IdCliente, COUNT(*) as NumeroVentas FROM Alquileres GROUP BY IdCliente");
                cn.Open();
                SqlDataAdapter sqlCli = new SqlDataAdapter(clientesql, cn);
                viewModel.Clientes = new DataTable();
                sqlCli.Fill(viewModel.Clientes);

            }
            using (SqlConnection cn = new SqlConnection(ConexionDB.conexion))
            {

                string juegosql = ("SELECT IdJuego, COUNT(*) as NumeroVentas FROM Alquileres GROUP BY IdJuego ;");
                cn.Open();
                SqlDataAdapter sqlJue = new SqlDataAdapter(juegosql, cn);
                viewModel.Juegos = new DataTable();
                sqlJue.Fill(viewModel.Juegos);

            }

            return View(viewModel);
            
        }
    }
}