using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio04.com.gft.model
{
    class Loja
    {
        String Nome { get; set; }

        String Cnpj { get; set; }

        List<Livro> Livros { get; set; }

        List<VideoGame> VideoGames { get; set; }

        public Loja()
        {
        }

        public Loja(string nome, string cnpj, List<Livro> livros, List<VideoGame> videoGames)
        {
            Nome = nome;
            Cnpj = cnpj;
            Livros = livros;
            VideoGames = videoGames;
        }

        public void ListaLivros()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("A Loja Americanas possui estes livros para venda:");
            foreach (Livro index in Livros)
            {
                if (index.QtdPag != 0 )
                {
                    Console.WriteLine("Titulo: {0} preço: R${1:0.00} quantidade: {2} em estoque", index.Nome, index.Preco, index.Qtd);
                }
                else
                {
                    Console.WriteLine("A loja não tem livros no seu estoque");
                }
            }
        }

        public void ListaVideoGames()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("A Loja Americanas possui estes video-games para venda:");
            foreach (VideoGame index in VideoGames)
            {
                if (index.Qtd != 0)
                {
                    Console.WriteLine("Video Game: {0} preço R${1:0.00}  quantidade: {2} em estoque", index.Modelo, index.Preco, index.Qtd);
                }
                else
                {
                    Console.WriteLine("A loja não tem video-games no seu estoque");
                }
            }
        }

        public void CalculaPatrimonio()
        {
            double valorPatrimonio = 0;

            if (Livros.Count == 0)
            {
                valorPatrimonio += 0;
            }
            else
            {
                foreach (Livro index in Livros)
                {
                    valorPatrimonio += (index.Preco * index.Qtd);
                }
            }

            if (VideoGames.Count == 0)
            {
                valorPatrimonio += 0;
            }
            else
            {
                foreach (VideoGame index in VideoGames)
                {
                    valorPatrimonio += (index.Preco * index.Qtd);
                }
            }

            Console.WriteLine("O Patrimonio da loja Americanas é: R$ {0:0.00}", valorPatrimonio);
        }

    }
}
