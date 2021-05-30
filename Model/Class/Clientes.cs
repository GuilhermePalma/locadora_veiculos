using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_veiculos.Model
{
    class Clientes
    {
        //Permite somente numeros Positivos e Inteiros 32Bits
        private uint id;
        private string cpf;
        private string nome;
        private string cnh;
        //Permite somente numeros Positivos e Inteiros 64Bits
        private ulong numeroTelefone;
        private string email;
        private string logradouro;
        //Permite somente numeros Positivos e Inteiros 64Bits
        private uint numeroEndereco;
        private string complemento;

        //Getters e Setters Usados para Inserir e Recuperar Valores
        public uint Id { get => id; set => id = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cnh { get => cnh; set => cnh = value; }
        public ulong NumeroTelefone { get => numeroTelefone; set => numeroTelefone = value; }
        public string Email { get => email; set => email = value; }
        public string Logradouro { get => logradouro; set => logradouro = value; }
        public uint NumeroEndereco { get => numeroEndereco; set => numeroEndereco = value; }
        public string Complemento { get => complemento; set => complemento = value; }

        //Metodo que instancia os objetos da Classe
        public Clientes(uint id, string cpf, string nome, string cnh, ulong numeroTelefone,
            string email, string logradouro, uint numeroEndereco, string complemento)
        {
            Id = id;
            Cpf = cpf;
            Nome = nome;
            Cnh = cnh;
            NumeroTelefone = numeroTelefone;
            Email = email;
            Logradouro = logradouro;
            NumeroEndereco = numeroEndereco;
            Complemento = complemento;
        }

        //Metodo Vazio usado para acessar objetos dentro da Classe
        public Clientes() { }
    }
}
