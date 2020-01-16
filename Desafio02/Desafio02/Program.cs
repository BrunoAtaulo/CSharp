using System;


namespace Desafio02
{
    class Program
    {
        static void Main(string[] args)
        {
            Carro carro1 = new Carro();
            Aviao aviao1 = new Aviao();

            String marcacarro, tipoaviao, usoaviao;
            int opcao, opcaoaviao, opcaocarro, qtdportas, anocarro;

            Console.WriteLine("Qual veiculo você deseja?\n1) Carro\n2) Aviao\n Qualquer outro : Sair");

            opcao = int.Parse(Console.ReadLine());

            do
            {
                if (opcao == 1)
                {
                    Console.WriteLine("Sobre o carro:\n1) Escolher marca do carro\n2) Escolher quantidade de portas do carro\n3) Escolher ano do carro \n7) Menu");
                    opcaocarro = int.Parse(Console.ReadLine());

                    switch (opcaocarro)
                    {
                        case 1:
                            //Marca do carro
                            Console.WriteLine("Digite a marca do carro");
                            marcacarro = Console.ReadLine();
                            carro1.marca = marcacarro;
                            Console.WriteLine("A marca do carro é: " + carro1.marca +"\n");
                            break;
                        case 2:
                            //Quantidade de portas do carro
                            Console.WriteLine("Digite a quantidade de portas do carro\n");
                            qtdportas = int.Parse(Console.ReadLine());
                            if (qtdportas <=5 && qtdportas > 0)
                            {
                                Console.WriteLine("A quantidade de portas do carro é: " + qtdportas + "\n");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Digite um número válido para a quantidade de portas\n");
                                break;
                            }
                        case 3:
                            //Ano do carro
                            Console.WriteLine("Digite o ano do carro");
                            anocarro = int.Parse(Console.ReadLine());
                            Console.WriteLine("O ano do carro é: " + anocarro + "\n");
                            break;
                        case 7:
                            //Menu
                            Console.WriteLine("Qual veiculo você deseja?\n1) Carro\n2) Aviao\n Qualquer outro : Sair\n");
                            opcao = int.Parse(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Opção inválida\n");
                            break;
                    }

                }
                else
                {
                    if (opcao == 2)
                    {
                        Console.WriteLine("Sobre o Aviao:\n1) Escolher o tipo do avião\n2) Escolher o uso do avião\n7) Menu\n");
                        opcaoaviao = int.Parse(Console.ReadLine());

                        switch (opcaoaviao)
                        {
                            case 1:
                                //Tipo do avião
                                Console.WriteLine("Digite o tipo do avião\n");
                                tipoaviao = Console.ReadLine();
                                Console.WriteLine("O tipo do avião é: " + tipoaviao + "\n");
                                break;
                            case 2:
                                //Uso do avião
                                Console.WriteLine("Digite o uso do avião\n");
                                usoaviao = Console.ReadLine();
                                Console.WriteLine("O tipo do avião é: " + usoaviao + "\n");
                                break;
                            case 7:
                                //Menu
                                Console.WriteLine("Qual veiculo você deseja?\n1) Carro\n2) Aviao\n Qualquer outro : Sair\n");
                                opcao = int.Parse(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Opção inválida\n");
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            } while (opcao != 1 || opcao !=2);
        }
    }
}
