using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio02
{
    class Carro : Veiculo
    {
        public String marca { get; set; }
        public int portas { get; set; }
        public int ano { get; set; }

        public Carro()
        {
        }
        
        public Carro(string modelo, double velocidade, int passageiros, double combustivel, string marca, int portas, int ano) : base (modelo, velocidade, passageiros, combustivel)
        { 
            this.marca = marca;
            this.portas = portas;
            this.ano = ano;
        }
    }
}
