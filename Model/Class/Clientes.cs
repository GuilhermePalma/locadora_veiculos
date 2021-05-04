using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_veiculos.Model
{
    class Clientes
    {
        private int id;
        private string cpf;
        private string nome;
        private string cnh;
        private int numeroTelefone;
        private string email;
        private string logradouro;
        private int numeroEndereco;
        private string complemento;

        public int Id { get => id; set => id = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cnh { get => cnh; set => cnh = value; }
        public int NumeroTelefone { get => numeroTelefone; set => numeroTelefone = value; }
        public string Email { get => email; set => email = value; }
        public string Logradouro { get => logradouro; set => logradouro = value; }
        public int NumeroEndereco { get => numeroEndereco; set => numeroEndereco = value; }
        public string Complemento { get => complemento; set => complemento = value; }

        public Clientes(int id, string cpf, string nome, string cnh, int numeroTelefone, string email, string logradouro, int numeroEndereco, string complemento)
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

        public Clientes() { }
    }
}
