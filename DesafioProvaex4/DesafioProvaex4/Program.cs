using DesafioProvaex4.com.gft.model;
using System;
using System.Collections.Generic;

namespace DesafioProvaex4
{
    class Program
    {
        static void Main(string[] args)
        {
            Gerente gerente1 = new Gerente("Carlos", 48, 25000);
            Supervisor supervisor1 = new Supervisor("Rodrigo", 20, 8000);
            Vendedor vendedor1 = new Vendedor("Luan Everton", 23, 2500);

            Console.WriteLine("O Gerente {0} Mattos, com a idade: {1}, tem o salario R${2:0.00}", gerente1.Nome, gerente1.Idade, gerente1.Salario);
            Console.WriteLine("O Supervisor {0}, com a idade: {1}, tem o salario R${2:0.00}", supervisor1.Nome, supervisor1.Idade, supervisor1.Salario);
            Console.WriteLine("O vendedor {0}, com a idade: {1}, tem o salario R${2:0.00}", vendedor1.Nome, vendedor1.Idade, vendedor1.Salario);

        }
    }
}
