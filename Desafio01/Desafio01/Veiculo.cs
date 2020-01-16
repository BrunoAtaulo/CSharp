using System;

namespace Desafio01
{
    class Veiculo
    {
        private String marca { get; set; }
        private String modelo { get; set; }
        private String placa { get; set; }
        private String cor { get; set; }
        private float km { get; set; }
        private Boolean isLigado { get; set; }
        private int litrosCombustivel { get; set; }
        private int velocidade { get; set; }
        private double preco { get; set; }

        //Métodos
        public void acelerar()
        {
            if (this.isLigado == true && this.litrosCombustivel>=1)
            {
                if (this.velocidade <= 160)
                {
                    this.velocidade += 20;
                    this.litrosCombustivel -= 1;
                    Console.WriteLine("Veiculo acelerado em 20 km\nVelocidade atual: " + velocidade + "km/h\n");
                }
                else
                {
                    Console.WriteLine("Não pode acelerar mais que 180 km/h\n");
                }
            }
            else
            {
                if (this.isLigado == false)
                {
                    Console.WriteLine("Veiculo desligado, para acelerar precisa estar com o veiculo ligado\n");
                }
                else
                {
                    Console.WriteLine("Veiculo sem combustivel, favor abastecer\n");
                }
            }
        }

        public void abastecer(int qtdcombustivel)
        {
            if (this.isLigado == false)
            {
                if (this.litrosCombustivel + qtdcombustivel > 100)
                {
                    Console.WriteLine("Não pode abastecer com " + qtdcombustivel + " pois fica acima do máximo (100L)\n");
                }
                else
                {
                    this.litrosCombustivel += qtdcombustivel;
                    this.velocidade = 0;
                    Console.WriteLine("Carro abastecido com " + qtdcombustivel + " litros de combustivel\nQuantidade de combustível atual: " + litrosCombustivel + " litros\n");
                }
            }
            else
            {
                Console.WriteLine("Não pode abastecer o veículo ligado\n");
            }
        }

        public void frear()
        {
            if (this.isLigado == true)
            {
                if(this.velocidade > 0)
                {
                    this.velocidade -= 10;
                    Console.WriteLine("Veiculo reduziu a velocidade em 10km\nVelocidade atual: " + this.velocidade + " km/h\n");
                }
                else
                {
                    Console.WriteLine("O carro já está parado, não precisa frear\n");
                }
            }else
            {
                Console.WriteLine("O carro não está ligado, para frear o carro precisa estar ligado\n");
            }
        }

        public void pintar(String corcarro)
        {
            this.velocidade = 0;
            Console.WriteLine("Veiculo pintado na cor " + corcarro + "\n");
        }

        public void ligar()
        {
            if (isLigado == false)
            {
                isLigado = true;
                Console.WriteLine("Carro ligado\n");
            }
            else
            {
                Console.WriteLine("O carro já estava ligado\n");
            }
        }

        public void desligar()
        {
            if (isLigado == true)
            {
                this.isLigado = false;
                this.velocidade = 0;
                Console.WriteLine("Carro desligado\n");
            }
            else
            {
                Console.WriteLine("O carro já estava desligado\n");
            }
        }
    }
}
