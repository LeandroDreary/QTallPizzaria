using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QTallPizzaria.Models;
using System.IO;
using System.Net;
using System.Data.Entity;

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

        [HttpPost, ActionName("Banner")]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarBanner(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banner Banner = db.banner.Find(id);
            if (Banner == null)
            {
                return HttpNotFound();
            }
            HttpPostedFileBase file = Request.Files["arquivoFoto"];
            if (file.ContentLength > 0)
            {
                string _FileName = (DateTime.Now + Path.GetExtension(file.FileName)).ToString();
                _FileName = _FileName.Replace("/", "").Replace(":", "").Replace(" ", "");
                file.SaveAs(Path.Combine(Server.MapPath("~/img/Home/banners/"), _FileName));
                Banner.diretorio = "../../img/Home/banners/" + _FileName;
                db.Entry(Banner).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Banner");
        }
    }
}