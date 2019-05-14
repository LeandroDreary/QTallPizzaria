using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QTallPizzaria.Models;

namespace QTallPizzaria.Controllers
{
    public class ProdutoController : Controller
    {
        private DBQtallEntities db = new DBQtallEntities();

        // GET: Produto
        public ActionResult Index()
        {
            var produto = db.Produto.Include(p => p.TipoProduto);
            return View(produto.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.idTipo = new SelectList(db.TipoProduto, "idTipo", "nomeTipo");
            return View();
        }

        // POST: Produto/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProduto,nome,preco,descricao,foto,idTipo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["arquivoFoto"];
                if (file.ContentLength > 0)
                {
                    string _FileName = (DateTime.Now + Path.GetExtension(file.FileName)).ToString();
                    _FileName = _FileName.Replace("/", "").Replace(":", "").Replace(" ", "");
                    file.SaveAs(Path.Combine(Server.MapPath("~/img/Home/produtos/"), _FileName));
                    produto.foto = "../../img/Home/produtos/" + _FileName;
                }
                if (produto.descricao == null)
                    produto.descricao = "";
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipo = new SelectList(db.TipoProduto, "idTipo", "nomeTipo", produto.idTipo);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipo = new SelectList(db.TipoProduto, "idTipo", "nomeTipo", produto.idTipo);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProduto,nome,preco,descricao,idTipo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["arquivoFoto"];
                DBQtallEntities dbSearch = new DBQtallEntities();
                if (file.ContentLength > 0)
                {      
                    string _path = dbSearch.Produto.Find(produto.idProduto).foto;
                    if (_path != null)
                    {
                        _path = _path.Replace("../", "").Insert(0, "~/");
                        if (System.IO.File.Exists(Server.MapPath(_path)))
                            System.IO.File.Delete(Server.MapPath(_path));
                    }
                    string _FileName = (DateTime.Now + Path.GetExtension(file.FileName)).ToString();
                    _FileName = _FileName.Replace("/", "").Replace(":", "").Replace(" ", "");
                    file.SaveAs(Path.Combine(Server.MapPath("~/img/Home/produtos/"), _FileName));
                    produto.foto = "../../img/Home/produtos/" + _FileName;
                }
                else
                    produto.foto = dbSearch.Produto.Find(produto.idProduto).foto;
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipo = new SelectList(db.TipoProduto, "idTipo", "nomeTipo", produto.idTipo);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
              
            Produto produto = db.Produto.Find(id);
            string _path = produto.foto.Replace("../", "").Insert(0, "~/"); 
            if (System.IO.File.Exists(_path))
                System.IO.File.Delete(_path);
            db.Produto.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Search()
        {
            string Pesquisa = Convert.ToString(Request["pesquisa"]);
            var produtos = db.Produto.Where(c => c.nome.Contains(Pesquisa)).ToList();
            return View("index", produtos.ToList());
        }
    }
}
