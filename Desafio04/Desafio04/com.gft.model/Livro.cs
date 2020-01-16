using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio04.com.gft.model
{
    class Livro : Produto
    {
        public String Autor { get; set; }
        public String Tema { get; set; }
        public int QtdPag { get; set; }

        public Livro()
        {
        }

        public Livro(string nome, double preco, int qtd, string autor, string tema, int qtdPag) : base (nome, preco, qtd)
        {
            Autor = autor;
            Tema = tema;
            QtdPag = qtdPag;
        }

        public double CalculaImposto()
        {
            double imp;
            if (Tema == "educativo")
            {
                Console.WriteLine("Não tem imposto\n");
                return 0;
            }
            else
            {
                imp = Preco * 0.1;
                //Preco = Preco + imp;
                return imp;
            }
        }
    }
}
