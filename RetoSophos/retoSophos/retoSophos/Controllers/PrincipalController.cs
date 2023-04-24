using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace retoSophos.Controllers
{
    public class PrincipalController : Controller
    {
        //Vista Principal y menu de Opciones
        public ActionResult Principal()
        {
            return View();
        }
    }
}