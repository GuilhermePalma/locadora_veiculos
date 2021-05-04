using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_veiculos.Model
{
    class Veiculos
    {

        private int id;
        private string placa;
        private string cidade;
        private int placa_mercosul;
        private string modelo;
        private string marca;
        private string cor;
        private int ano;
        private string status;


        public int Id { get => id; set => id = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public int Placa_mercosul { get => placa_mercosul; set => placa_mercosul = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Cor { get => cor; set => cor = value; }
        public int Ano { get => ano; set => ano = value; }
        public string Status { get => status; set => status = value; }

        public Veiculos(int id, string placa, string cidade, int placa_mercosul, string modelo,
        string marca, string cor, int ano, string status)
        {
            Id = id;
            Placa = placa;
            Cidade = cidade;
            Placa_mercosul = placa_mercosul;
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Ano = ano;
            Status = status;
        }

         public Veiculos() { } //Metodo Vazio
        

    }
}
