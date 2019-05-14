using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QTallPizzaria.Models
{
    public class EditarViewModel
    {
        public List<Destaques> Destaques { get; set; }
        public List<Lanche> Lanches { get; set; }
        public List<Pizza> Pizza { get; set; }
        public List<Bebida> Bebidas { get; set; }

        public EditarViewModel()
        {
            Destaques = new List<Destaques>();
            Lanches = new List<Lanche>();
            Pizza = new List<Pizza>();
            Bebidas = new List<Bebida>();
        }

    }

    public class Destaques
    {
        public string NomeProduto { get; set; }
        public string Foto { get; set; }
        public decimal? preco { get; set; }
    }
}