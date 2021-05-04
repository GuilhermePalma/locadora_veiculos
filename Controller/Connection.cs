using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_veiculos.Controller
{
    class Connection
    {
        string connection;

        public String ExecuteConnection()
        {
            //define string de conexao e cria a conexao
            string server = "localhost";
            string database = "locadora_veiculos";
            string uid = "root";
            string password = "";

            connection = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";;Convert Zero Datetime=true;";

            return connection;
        }

    }
}
