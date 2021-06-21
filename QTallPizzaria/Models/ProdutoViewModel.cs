using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QTallPizzaria.Models
{
    public class ProdutoViewModel
    {
        public List<Lanche> Lanches { get; set; }
        public List<Pizza> Pizza { get; set; }
        public List<Bebida> Bebidas { get; set; }
        public List<Prato> Prato { get; set; }
        public List<Porcao> Porcoes { get; set; }
        public List<Esfirra> Esfirras { get; set; }
        public List<Espetinho> Espetinhos { get; set; }

        public ProdutoViewModel()
        {
            Lanches = new List<Lanche>();
            Pizza = new List<Pizza>();
            Bebidas = new List<Bebida>();
            Prato = new List<Prato>();
            Porcoes = new List<Porcao>();
            Esfirras = new List<Esfirra>();
            Espetinhos = new List<Espetinho>();
        }

    }

    public class Lanche
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public decimal? preco { get; set; }
    }

    public class Pizza
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public decimal? preco { get; set; }
    }
    public class Bebida
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public decimal? preco { get; set; }
    }
    public class Prato
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public decimal? preco { get; set; }
    }
    public class Porcao
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public decimal? preco { get; set; }
    }
    public class Esfirra
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public decimal? preco { get; set; }
    }
    public class Espetinho
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public decimal? preco { get; set; }
    }
}