using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio03.Model
{
    abstract class Veiculo
    {
        private String modelo { get; set; }
        private double velocidade { get; set; }
        private int passageiros { get; set; }
        private double combustivel { get; set; }

        protected Veiculo()
        {
        }
       

        protected Veiculo(string modelo, double velocidade, int passageiros, double combustivel)
        {
            this.modelo = modelo;
            this.velocidade = velocidade;
            this.passageiros = passageiros;
            this.combustivel = combustivel;
        }
    }
}
