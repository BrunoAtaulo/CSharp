using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioProvaex4.com.gft.model
{
    class Supervisor : Funcionario
    {
        public Supervisor(string nome, int idade, double salario) : base(nome, idade, salario)
        {

        }

        public override double Bonificacao()
        {
            return Salario + 5000;
        }
    }
}
