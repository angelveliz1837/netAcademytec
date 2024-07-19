using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infraestructure.SQL.Negocios;
using Domain.Entity;

namespace academytec_Net.Controllers
{
    public class NegociosController : Controller
    {
        almacenDAO _almacen = new almacenDAO();
        public ActionResult Index()
        {
            return View(_almacen.getAll());
        }
    }
}