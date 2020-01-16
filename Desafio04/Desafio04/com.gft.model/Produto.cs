using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio04.com.gft.model
{
    abstract class Produto
    {
        public String Nome { get; set; }
        public  double Preco { get; set; }
        public int Qtd { get; set; }

        public Produto()
        {
        }

        public Produto(string nome, double preco, int qtd)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.Qtd = qtd;
        }
    }
}
