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

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.PizzasDestaque = db.Produto.Where(p => p.idTipo == 1 && p.DESTAQUES == true).OrderByDescending(p => p.DATAMODIFICACAODESTAQUE).Take(3).ToList();
            ViewBag.PizzasSugestao = db.Produto.Where(p => p.idTipo == 1 && p.SUGESTAO == true).OrderByDescending(p => p.DATAMODIFICACAOSUGESTAO).Take(3).ToList();
            ViewBag.BebidasSugestao = db.Produto.Where(p => p.idTipo == 2 && p.SUGESTAO == true).OrderByDescending(p => p.DATAMODIFICACAOSUGESTAO).Take(3).ToList();
            ViewBag.LanchesSugestao = db.Produto.Where(p => p.idTipo == 3 && p.SUGESTAO == true).OrderByDescending(p => p.DATAMODIFICACAOSUGESTAO).Take(3).ToList();
            ViewBag.HeaderBackground = db.banner.Find(1).diretorio;

            return View();
        }

        public ActionResult Cardapio()
        {
            ProdutoViewModel pvm = new ProdutoViewModel();
            foreach (var item in db.Produto.Where(p => p.idTipo == 1))
            {
                pvm.Pizza.Add(new Pizza() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = LimitarString.Retorno(item.descricao, 200)});
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 2))
            {
                pvm.Bebidas.Add(new Bebida() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = LimitarString.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 3))
            {
                pvm.Lanches.Add(new Lanche() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = LimitarString.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 4))
            {
                pvm.Prato.Add(new Prato() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = LimitarString.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 5))
            {
                pvm.Porcoes.Add(new Porcao() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = LimitarString.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 6))
            {
                pvm.Esfirras.Add(new Esfirra() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = LimitarString.Retorno(item.descricao, 200) });
            }
            foreach (var item in db.Produto.Where(p => p.idTipo == 7))
            {
                pvm.Espetinhos.Add(new Espetinho() { Foto = item.foto, NomeProduto = item.nome, preco = item.preco, Descricao = LimitarString.Retorno(item.descricao, 200) });
            }
            ViewBag.HeaderBackground = db.banner.Find(2).diretorio;
            return View(pvm);
        }

        public ActionResult Galeria()
        {
            ViewBag.HeaderBackground = db.banner.Find(3).diretorio;
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.HeaderBackground = db.banner.Find(4).diretorio;
            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.HeaderBackground = db.banner.Find(5).diretorio;
            return View();
        }
    }
}