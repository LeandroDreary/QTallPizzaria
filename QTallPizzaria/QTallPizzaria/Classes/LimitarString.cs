using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QTallPizzaria.Classes
{
    public static class LimitarString
    {
        public static string Retorno(string texto,int Quant)
        {
            string textoReturn = texto;
            if(texto == null)
            {
                return textoReturn = "";
            }
            else
            if (texto.Length > Quant)
            {
                if (texto[Quant] != Convert.ToChar(" "))
                {
                    textoReturn = "";
                    int posicao = Quant;
                    for (int i = Quant; texto[i] != Convert.ToChar(" "); i--)
                        posicao = i;
                    for (int i = 0; i < (posicao - 1); i++)
                        textoReturn += texto[i];
                }
                return textoReturn + "...";
            }
            else
                return textoReturn;
        }
    }
}