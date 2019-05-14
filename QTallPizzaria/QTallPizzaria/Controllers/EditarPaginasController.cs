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

        public ActionResult PaginaInicial()
        {
            var evm = new EditarViewModel();
            for(var i = 1; i <= 3; i++)
            evm.Destaques.Add(new Destaques() { NomeProduto = db.Produto.Find(db.Destaque.Find(i).idDestaque).nome,
                                                Foto = db.Produto.Find(db.Destaque.Find(i).idDestaque).foto,
                                                preco = db.Produto.Find(db.Destaque.Find(i).idDestaque).preco  });

            foreach(var item in db.Sugestao.ToList())
            {
                if (item.idTipo == 1)
                   evm.Pizza.Add(new Pizza      { NomeProduto = db.Produto.Find(item.idProduto).nome,
                                                  Foto = db.Produto.Find(item.idProduto).foto,
                                                  preco = db.Produto.Find(item.idProduto).preco,
                                                  Descricao = db.Produto.Find(item.idProduto).descricao });
                if (item.idTipo == 2)
                    evm.Bebidas.Add(new Bebida { NomeProduto = db.Produto.Find(item.idProduto).nome,
                                                 Foto = db.Produto.Find(item.idProduto).foto,
                                                 preco = db.Produto.Find(item.idProduto).preco,
                                                 Descricao = db.Produto.Find(item.idProduto).descricao
                    });
                if (item.idTipo == 3)
                    evm.Lanches.Add(new Lanche { NomeProduto = db.Produto.Find(item.idProduto).nome,
                                                 Foto = db.Produto.Find(item.idProduto).foto,
                                                 preco = db.Produto.Find(item.idProduto).preco,
                                                 Descricao = db.Produto.Find(item.idProduto).descricao
                    });
            }      
            return View(evm);
        }
    }
}