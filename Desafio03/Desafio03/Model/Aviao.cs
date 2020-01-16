using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio03.Model
{
    class Aviao : Veiculo
    {
        public string tipo { get; set; }
        public string uso { get; set; }

        public Aviao()
        {
        }

        public Aviao(string modelo, double velocidade, int passageiros, double combustivel, string tipo, string uso) : base(modelo, velocidade, passageiros, combustivel)
        {
            this.tipo = tipo;
            this.uso = uso;
        }
    }
}
