using QTallPizzaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QTallPizzaria.Classes;

namespace QTallPizzaria.Controllers
{
    public class HomeController : Controller
    {
        private DBQtallEntities db = new DBQtallEntities();
        LimitarString limitar = new LimitarString();
        // GET: Home
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
            ViewBag.HeaderBackground = db.banner.Find(1).diretorio;
            return View(evm);
        }

        public ActionResult Cardapio()
        {
            ProdutoViewModel pvm = new ProdutoViewModel();
            foreach (var item in db.Produto.Where(p => p.idTipo == 1))
            {
                pvm.Pizza.Add(new Pizza() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = limitar.Retorno(item.descricao, 200)});
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 2))
            {
                pvm.Bebidas.Add(new Bebida() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = limitar.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 3))
            {
                pvm.Lanches.Add(new Lanche() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = limitar.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 4))
            {
                pvm.Prato.Add(new Prato() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = limitar.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 5))
            {
                pvm.Porcoes.Add(new Porcao() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = limitar.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 6))
            {
                pvm.Esfirras.Add(new Esfirra() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = limitar.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 7))
            {
                pvm.Espetinhos.Add(new Espetinho() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = limitar.Retorno(item.descricao, 200) });
            }
            return View(pvm);
        }

        public ActionResult Galeria()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }
    }
}