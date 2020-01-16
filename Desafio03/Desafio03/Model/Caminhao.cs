using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio03.Model
{
    class Caminhao : Veiculo
    {
		public float peso { get; set; }

		public Caminhao()
		{

		}

		public Caminhao(string modelo, double velocidade, int passageiros, double combustivel, float peso) : base (modelo, velocidade, passageiros, combustivel)
		{
			this.peso = peso;
		}
	}
}
