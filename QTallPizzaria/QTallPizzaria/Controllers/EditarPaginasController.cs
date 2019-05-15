using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QTallPizzaria.Models;
using System.IO;

namespace QTallPizzaria.Controllers
{
    public class EditarPaginasController : Controller
    {
        private DBQtallEntities db = new DBQtallEntities();

        // GET: EditarPaginas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Banner()
        {
            var banners = db.banner;
            return View(banners.ToList());
        }
    }
}