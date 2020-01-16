using System;

namespace Desafio01
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao, qtdlitros;
            String corcarro;

            Veiculo carro = new Veiculo();

            do
            {
                Console.WriteLine("MENU\n\nDigite a opcao desejada:\n1) Ligar\n2) Desligar\n3) Acelerar\n4) Frear\n5) Abastecer\n"
                + "6) Pintar carro\n7) Sair\n");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        //Ligar
                        carro.ligar();
                        break;
                    case 2:
                        //Desligar
                        carro.desligar();
                        break;
                    case 3:
                        //Acelerar
                        carro.acelerar();
                        break;
                    case 4:
                        //Frear
                        carro.frear();
                        break;
                    case 5:
                        //Abastecer
                        Console.WriteLine("Quantos litros deseja abastecer?");
                        qtdlitros = int.Parse(Console.ReadLine());
                        carro.abastecer(qtdlitros);
                        break;
                    case 6:
                        //Pintar
                        Console.WriteLine("Qual a cor do veículo?");
                        corcarro = Console.ReadLine();
                        carro.pintar(corcarro);
                        break;
                    case 7:
                        //Sair
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opcao != 7);

        }
    }
}
