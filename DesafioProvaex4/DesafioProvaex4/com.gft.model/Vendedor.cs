using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioProvaex4.com.gft.model
{
    class Vendedor : Funcionario
    {
        public Vendedor(string nome, int idade, double salario) : base(nome, idade, salario)
        {

        }

        public override double Bonificacao()
        {            
            return Salario + 3000;
        }
    }
}
