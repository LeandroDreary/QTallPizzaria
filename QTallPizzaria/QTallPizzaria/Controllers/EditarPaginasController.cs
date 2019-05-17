using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QTallPizzaria.Models;
using System.IO;
using System.Net;
using System.Data.Entity;
using QTallPizzaria.Classes;

namespace QTallPizzaria.Controllers
{
    public class EditarPaginasController : Controller
    {
        private DBQtallEntities db = new DBQtallEntities();
        LimitarString limitar = new LimitarString();

        // GET: EditarPaginas
        public ActionResult Index()
        {
            var evm = new EditarViewModel();

            for (var i = 1; i <= 3; i++)
                evm.Destaques.Add(new Destaques()
                {
                    NomeProduto = db.Produto.Find(db.Destaque.Find(i).idDestaque).nome,
                    Foto = db.Produto.Find(db.Destaque.Find(i).idDestaque).foto,
                    preco = db.Produto.Find(db.Destaque.Find(i).idDestaque).preco
                });
            foreach (var item in db.Sugestao.ToList())
            {
                if (item.idTipo == 1)
                    evm.Pizza.Add(new Pizza
                    {
                        NomeProduto = db.Produto.Find(item.idProduto).nome,
                        Foto = db.Produto.Find(item.idProduto).foto,
                        preco = db.Produto.Find(item.idProduto).preco,
                        Descricao = limitar.Retorno(db.Produto.Find(item.idProduto).descricao, 100)
                    });
                if (item.idTipo == 2)
                    evm.Bebidas.Add(new Bebida
                    {
                        NomeProduto = db.Produto.Find(item.idProduto).nome,
                        Foto = db.Produto.Find(item.idProduto).foto,
                        preco = db.Produto.Find(item.idProduto).preco,
                        Descricao = limitar.Retorno(db.Produto.Find(item.idProduto).descricao, 100)
                    });
                if (item.idTipo == 3)
                    evm.Lanches.Add(new Lanche
                    {
                        NomeProduto = db.Produto.Find(item.idProduto).nome,
                        Foto = db.Produto.Find(item.idProduto).foto,
                        preco = db.Produto.Find(item.idProduto).preco,
                        Descricao = limitar.Retorno(db.Produto.Find(item.idProduto).descricao, 100)
                    });
            }

            ViewBag.idTipoPizzas = new SelectList(db.Produto.Where(p => p.idTipo == 1),"idProduto", "nome");
            ViewBag.idTipoBebidas = new SelectList(db.Produto.Where(p => p.idTipo == 2),"idProduto", "nome");
            ViewBag.idTipoLanches = new SelectList(db.Produto.Where(p => p.idTipo == 3),"idProduto", "nome");
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