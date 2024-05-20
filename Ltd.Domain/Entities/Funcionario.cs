using Ltd.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;


namespace Ltd.Domain.Entities
{

    public class Funcionario
    {
        public int Id { get; private set; }
        public int Idade { get; private set; }
        public string Nome { get; private set; }
        public string Cargo { get; private set; }

        public Funcionario(int id,int idade, string nome, string cargo)
        {
            DomainExceptionValidation.When(id < 0, "o Id do funcionário deve ser um valor positivo.");
            Id = id;
            ValidateDomain(idade, nome, cargo);
        }
        public void Update(int idade, string nome, string cargo)
        {
            ValidateDomain(idade, nome, cargo);
        }
        public void ValidateDomain(int idade, string nome, string cargo)
        {
            DomainExceptionValidation.When(idade < 0, "A idade deve ser um valor positivo.");
            DomainExceptionValidation.When(idade == 0, "A idade não pode ser zero.");
            DomainExceptionValidation.When(idade > 120, "A idade não pode maior que 120 anos.");
            Idade = idade;
            Nome = nome;
            Cargo = cargo;
        }
    }
}

