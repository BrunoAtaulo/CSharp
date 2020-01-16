using System;

namespace DesafioProvaex4.com.gft.model
{
    abstract class Funcionario
    {
        public String Nome { get; set; }
        public int Idade { get; set; }
        public double Salario { get; set; }

        protected Funcionario()
        {
        }

        protected Funcionario(string nome, int idade, double salario)
        {
            Nome = nome;
            Idade = idade;
            Salario = salario;
        }

        public virtual double Bonificacao()
        {
            return Salario;
        }


    }
}