using locadora_veiculos.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_veiculos.Model
{
    class ClienteModel
    {
        public string erro;
        public List<Clientes> clientesList = new List<Clientes>();
        public int registrosAfetados;
        private Connection urlDB = new Connection();


        public Boolean SelectClientesID(Clientes cliente)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());

            MySqlCommand QuerrySelect = Connect.CreateCommand();
            QuerrySelect.CommandText = "SELECT * FROM clientes WHERE id_cli=?id";

            QuerrySelect.Parameters.AddWithValue("?id", cliente.Id);

            try
            {
                Connect.Open();
                //N° de linhas afetadas
                registrosAfetados = QuerrySelect.ExecuteNonQuery();

                //Armazena os dados obtidos
                MySqlDataReader dataReader;
                dataReader = QuerrySelect.ExecuteReader();

                bool existRecord = false;
                existRecord = dataReader.HasRows;

                if (existRecord)
                {
                    while (dataReader.Read())
                    {
                        //Clientes clienteArray = new Clientes(0, "", "", "", 0, "", "", 0, "");
                        Clientes clienteArray = new Clientes();

                        clienteArray.Id = dataReader.GetInt32(dataReader.GetOrdinal("id_cli"));
                        clienteArray.Cpf = dataReader.GetString(dataReader.GetOrdinal("cpf"));
                        clienteArray.Nome = dataReader.GetString(dataReader.GetOrdinal("nome"));
                        clienteArray.Cnh= dataReader.GetString(dataReader.GetOrdinal("cnh"));
                        clienteArray.NumeroTelefone= dataReader.GetInt32(dataReader.GetOrdinal("num_tel"));
                        clienteArray.Email= dataReader.GetString(dataReader.GetOrdinal("email"));
                        clienteArray.Logradouro = dataReader.GetString(dataReader.GetOrdinal("logradouro"));
                        clienteArray.NumeroEndereco = dataReader.GetInt32(dataReader.GetOrdinal("numero"));
                        clienteArray.Complemento= dataReader.GetString(dataReader.GetOrdinal("complemento"));

                        clientesList.Add(clienteArray);
                    }

                    if (clientesList.Count() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        erro = "Existem" + registrosAfetados + "valores com esse ID";
                        return false;
                    }
                }
                else
                {
                    erro = "Não Existe de um valor com esse ID";
                    return false;
                }

            }
            catch (Exception ex)
            {
                erro = "Erro Na Conexão com o Banco de Dados\n\nErro:\n" + ex.ToString();
                return false;
            }
            finally
            {
                QuerrySelect.Dispose();
                Connect.Close();
            }

        }


        public Boolean InsertClientes(Clientes cliente)
        {

            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());
            MySqlCommand QuerryInsert = Connect.CreateCommand();

            QuerryInsert.CommandText = "INSERT INTO clientes(cpf, nome, cnh, " +
                "num_tel, email, logradouro, numero, complemento) values(?cpf, ?nome, ?cnh, " +
                "?num_tel, ?email, ?logradouro, ?numero, ?complemento)";

            QuerryInsert.Parameters.AddWithValue("?cpf", cliente.Cpf);
            QuerryInsert.Parameters.AddWithValue("?nome", cliente.Nome);
            QuerryInsert.Parameters.AddWithValue("?cnh", cliente.Cnh);
            QuerryInsert.Parameters.AddWithValue("?num_tel", cliente.NumeroTelefone);
            QuerryInsert.Parameters.AddWithValue("?email", cliente.Email);
            QuerryInsert.Parameters.AddWithValue("?logradouro", cliente.Logradouro);
            QuerryInsert.Parameters.AddWithValue("?numero", cliente.NumeroEndereco);
            QuerryInsert.Parameters.AddWithValue("?complemento", cliente.Complemento);


            try
            {
                Connect.Open();
                // Executa o Comando
                QuerryInsert.ExecuteNonQuery();
                return true;
            }

            catch (MySqlException ex)
            {
                //Exceção No Banco de Dados
                erro = "Erro Na Conexão com o Banco de Dados\n\nErro:\n" + ex.ToString();

                return false;
            }
            finally
            {
                Connect.Close();
            }

        }


        public Boolean UpdateCliente(Clientes cliente)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());
            MySqlCommand QuerryUpdate = Connect.CreateCommand();

            QuerryUpdate.CommandText = "UPDATE clientes SET cpf=?cpf, nome=?nome, cnh=?cnh, " +
                "num_tel=?num_tel, email=?email, logradouro=?logradouro, numero=?numero, complemento=?complemento " +
                "WHERE id_cli=?id_cli";

            QuerryUpdate.Parameters.AddWithValue("?cpf", cliente.Cpf);
            QuerryUpdate.Parameters.AddWithValue("?nome", cliente.Nome);
            QuerryUpdate.Parameters.AddWithValue("?cnh", cliente.Cnh);
            QuerryUpdate.Parameters.AddWithValue("?num_tel", cliente.NumeroTelefone);
            QuerryUpdate.Parameters.AddWithValue("?email", cliente.Email);
            QuerryUpdate.Parameters.AddWithValue("?logradouro", cliente.Logradouro);
            QuerryUpdate.Parameters.AddWithValue("?numero", cliente.NumeroEndereco);
            QuerryUpdate.Parameters.AddWithValue("?complemento", cliente.Complemento);
            QuerryUpdate.Parameters.AddWithValue("?id_cli", cliente.Id);

            try
            {
                Connect.Open();
                // Executa o Comando
                registrosAfetados = QuerryUpdate.ExecuteNonQuery();
                return true;

            }
            catch (MySqlException ex)
            {
                //Exceção No Banco de Dados
                erro = "Erro Na Conexão com o Banco de Dados\n\nErro:\n" + ex.ToString();
                return false;
            }
            finally
            {
                Connect.Close();
            }

        }


        public Boolean DeleteVeiculo(Clientes cliente)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());
            MySqlCommand QuerryDelete = Connect.CreateCommand();

            QuerryDelete.CommandText = "DELETE FROM clientes WHERE id_cli=?id_cli";
            QuerryDelete.Parameters.AddWithValue("?id_cli", cliente.Id);

            try
            {
                Connect.Open();
                QuerryDelete.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                //Exceção No Banco de Dados
                erro = "Erro Na Conexão com o Banco de Dados\n\nErro:\n" + ex.ToString();
                return false;
            }
            finally
            {
                Connect.Close();
            }

        }


        public Boolean ListVeiculos()
        {
            // Pega a String da classe ConnectDB
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());

            MySqlCommand QuerryAllSelect = Connect.CreateCommand();
            QuerryAllSelect.CommandText = "SELECT * FROM clientes";

            try
            {
                Connect.Open();

                QuerryAllSelect.ExecuteNonQuery();

                //Armazena os dados obtidos
                MySqlDataReader dataReader;

                dataReader = QuerryAllSelect.ExecuteReader();

                bool existRecord = false;

                existRecord = dataReader.HasRows;

                if (existRecord)
                {
                    while (dataReader.Read())
                    {
                        //Clientes clienteArray = new Clientes(0, "", "", "", 0, "", "", 0, "");
                        Clientes clienteArray = new Clientes();

                        clienteArray.Id = dataReader.GetInt32(dataReader.GetOrdinal("id_cli"));
                        clienteArray.Cpf = dataReader.GetString(dataReader.GetOrdinal("cpf"));
                        clienteArray.Nome = dataReader.GetString(dataReader.GetOrdinal("nome"));
                        clienteArray.Cnh = dataReader.GetString(dataReader.GetOrdinal("cnh"));
                        clienteArray.NumeroTelefone = dataReader.GetInt32(dataReader.GetOrdinal("num_tel"));
                        clienteArray.Email = dataReader.GetString(dataReader.GetOrdinal("email"));
                        clienteArray.Logradouro = dataReader.GetString(dataReader.GetOrdinal("logradouro"));
                        clienteArray.NumeroEndereco = dataReader.GetInt32(dataReader.GetOrdinal("numero"));
                        clienteArray.Complemento = dataReader.GetString(dataReader.GetOrdinal("complemento"));

                        clientesList.Add(clienteArray);
                    }

                    QuerryAllSelect.Connection.Close();
                    QuerryAllSelect.Dispose();

                    return true;
                }
                else
                {
                    erro = "Não Foi Encontrado Nenhum Registro No Banco de Dados...";
                    return false;
                }

            }
            catch (MySqlException ex)
            {
                erro = "Erro Na Conexão com o Banco de Dados\n\nErro:\n" + ex.ToString();
                return false;

            }
            finally
            {
                Connect.Close();
            }

        }


    }
}
