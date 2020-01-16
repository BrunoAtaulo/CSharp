using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio04.com.gft.model
{
    class VideoGame : Produto
    {
        public String Marca { get; set; }

        public String Modelo { get; set; }

        public bool IsUsado { get; set; }

        public VideoGame()
        {
        }

        public VideoGame(string nome, double preco, int qtd, string marca, string modelo, bool isUsado) : base(nome, preco, qtd)
        {
            Marca = marca;
            Modelo = modelo;
            IsUsado = isUsado;
        }

        public double CalculaImposto()
        {
            double imp;

            if (this.IsUsado == true)
            {
                imp = Preco * 0.25;
                //Preco = Preco + imp;
                Console.WriteLine("Imposto " + Nome + " usado, " + imp); 
                return imp;
            }
            else
            {
                imp = Preco * 0.45;
                //Preco = Preco + imp;
                Console.WriteLine("Imposto " + Nome + ", " + imp);
                return imp;
            }


        
        }



    }
}
