using System;
using System.Collections.Generic;

namespace DesafioProva
{
    class Program
    {
        static void Main(string[] args)
        {
            //1)Instancie o objeto e a Lista<Pessoa>, adicione os dados conforme a tabela abaixo e por fim imprima o nome da pessoa mais velha
            Console.WriteLine("Questão 1:\n");

            Pessoa pessoa1 = new Pessoa("João", 15);
            Pessoa pessoa2 = new Pessoa("Leandro", 21);
            Pessoa pessoa3 = new Pessoa("Paulo", 17);
            Pessoa pessoa4 = new Pessoa("Jessica", 18);

            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(pessoa1);
            pessoas.Add(pessoa2);
            pessoas.Add(pessoa3);
            pessoas.Add(pessoa4);

            int maior = 0;
            String nomemaior = "";

            foreach (Pessoa index in pessoas)
            {
                if (index.Idade > maior)
                {
                    maior = index.Idade;
                    nomemaior = index.Nome;
                }
            }

            Console.WriteLine("A pessoa mais velha é {0}, com {1} anos\n\n", nomemaior, maior);

            Console.WriteLine("Fim questão 1\n------------------------------------------------------------------\n");

            Console.WriteLine("Questão 2:\n");

            Console.WriteLine("Lista antes da exclusão\n");
            foreach (Pessoa index in pessoas)
            {
                Console.WriteLine("Nome: {0}, Idade: {1} anos", index.Nome, index.Idade);
            }


            /* Método tradicional (maior) para excluir usando o For each
            foreach (Pessoa index in pessoas.ToArray())
            {
                if (index.Idade < 18)
                {
                    pessoas.Remove(index);
                }
            }
            */

            pessoas.RemoveAll(i => i.Idade < 18);
            Console.WriteLine("\nLista depois da exclusão: \n");

            foreach (Pessoa index in pessoas)
            {
                Console.WriteLine("Nome: {0}, Idade: {1} anos", index.Nome, index.Idade);
            }

            Console.WriteLine("\nFim questão 2\n------------------------------------------------------------------\n");

            Console.WriteLine("Questão 3:\n");
            Console.WriteLine("Consulte se o objeto Jessica existe na lista e exiba a sua idade.");

            foreach (Pessoa index in pessoas)
            {
                if (index.Nome == "Jessica")
                {
                    Console.WriteLine("Nome: {0}, Idade: {1} anos\n", index.Nome, index.Idade);
                }
            }
            Console.WriteLine("Fim questão 3\n------------------------------------------------------------------\n");

        }
    }
}
