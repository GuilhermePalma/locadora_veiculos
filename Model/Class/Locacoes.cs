using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_veiculos.Model.Class
{
    class Locacoes
    {
        private int id_locacao;
        private string cpf;
        private string placa;
        private double valor_locacao;
        private DateTime data_retirada;
        private DateTime data_entrega;

        public int Id_locacao { get => id_locacao; set => id_locacao = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Placa { get => placa; set => placa = value; }
        public double Valor_locacao { get => valor_locacao; set => valor_locacao = value; }
        public DateTime Data_retirada { get => data_retirada; set => data_retirada = value; }
        public DateTime Data_entrega { get => data_entrega; set => data_entrega = value; }

        public Locacoes(int id_locacao, string cpf, string placa, double valor_locacao, DateTime data_retirada, DateTime data_entrega)
        {
            Id_locacao = id_locacao;
            Cpf = cpf;
            Placa = placa;
            Valor_locacao = valor_locacao;
            Data_retirada = data_retirada;
            Data_entrega = data_entrega;
        }

        public Locacoes() { }

        

   /*     public double calcPaymment(int days, double value)
        {
            double valueFinal = days * value;
            return valueFinal;
        }*/

       /* public int calcDays(string date1, string date2)
        {
            int day1 = Convert.ToInt32(date1.Substring(9, 2));
            int month1 = Convert.ToInt32(date1.Substring(6, 2));
            int year1 = Convert.ToInt32(date1.Substring(0, 4));

            int day2 = Convert.ToInt32(date2.Substring(9, 2));
            int month2 = Convert.ToInt32(date2.Substring(6, 2));
            int year2 = Convert.ToInt32(date2.Substring(0, 4));

            int day = day2 - day1;
            int month = month2 - month1;
            int year = year2 - year1;

            if (year <= 1)
            {
                day = day + (year * 365);
            }
            else if (month <= 1)
            {
                day = day + (month * 30);
            }

            return day;

        }*/

     /*  public double calcTaxa(double valueFinal, double valueTaxaDay, int days)
        {
            double valueFinalTaxa = valueFinal + (days * valueTaxaDay);
            return valueFinalTaxa;
        }*/


    }
}
