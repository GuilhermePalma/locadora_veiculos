using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_veiculos.Controller
{
    class DataBase
    {
        string stringConnection;
        private MySqlConnection Connection;

        /* TODO Metodo que será retirado
           Ainda em Utilização pela Locação e Veiculos */
        public String ExecuteConnection()
        {
            //define string de conexao e cria a conexao
            string server = "localhost";
            string database = "locadora_veiculos";
            string uid = "root";
            string password = "";

            stringConnection = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";;Convert Zero Datetime=true;";

            return stringConnection;
        }

        /* Cria uma Conexão ja no Formato MySql 
            Sendo somente necessario inicia-la */
        public MySqlConnection CreateConnection()
        {
            //define string de conexao e cria a conexao
            string server = "localhost";
            string database = "locadora_veiculos";
            string uid = "root";
            string password = "";

            stringConnection = "SERVER=" + server + ";" + 
                "DATABASE=" + database + ";" + 
                "UID=" + uid + ";" + 
                "PASSWORD=" + password +
                ";;Convert Zero Datetime=true;";

            return new MySqlConnection(stringConnection);
        }

        //Executa comandos que alteram o Banco de Dados (Inserts, Udpates, Deletes)
        public void ExecuteCommand(string stringCommand)
        {
            Connection = CreateConnection();

            MySqlCommand Command = new MySqlCommand(stringCommand, Connection);

            Connection.Open();

            Command.ExecuteNonQuery();

        }

        //Executa comandos que não alteraram o Banco de Dados (Selects)
        public MySqlDataReader returnCommand(String command)
        {
            Connection = CreateConnection();

            MySqlCommand Querry = new MySqlCommand(command, Connection);

            Connection.Open();

            return Querry.ExecuteReader();
        }

        //Desativa/Fecha caso tenha uma conexão Aberta
        public void Dispose()
        {
            if(CreateConnection().State == ConnectionState.Open)
            {
                CreateConnection().Close();
            }
        }

    }
}
