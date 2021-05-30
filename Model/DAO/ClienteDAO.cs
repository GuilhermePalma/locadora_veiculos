using locadora_veiculos.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_veiculos.Model
{
    class ClienteDAO
    {
        public string erro;
        public List<Clientes> clientesList = new List<Clientes>();
        private DataBase op_database = new DataBase();


        public Boolean SelectClientesID(Clientes cliente)
        {
            string querrySelectId = string.Format("SELECT * FROM clientes WHERE id_cli = '{0}'", cliente.Id);

            try
            {
                //Armazena os dados obtidos
                MySqlDataReader dataReader;

                dataReader = op_database.returnCommand(querrySelectId);

                bool existRecord = false;
                existRecord = dataReader.HasRows;

                if (existRecord)
                {
                    while (dataReader.Read())
                    {
                        Clientes clienteArray = new Clientes();

                        clienteArray.Id = dataReader.GetUInt32(dataReader.GetOrdinal("id_cli"));
                        clienteArray.Cpf = dataReader.GetString(dataReader.GetOrdinal("cpf"));
                        clienteArray.Nome = dataReader.GetString(dataReader.GetOrdinal("nome"));
                        clienteArray.Cnh = dataReader.GetString(dataReader.GetOrdinal("cnh"));
                        clienteArray.NumeroTelefone = dataReader.GetUInt64(dataReader.GetOrdinal("num_tel"));
                        clienteArray.Email = dataReader.GetString(dataReader.GetOrdinal("email"));
                        clienteArray.Logradouro = dataReader.GetString(dataReader.GetOrdinal("logradouro"));
                        clienteArray.NumeroEndereco = dataReader.GetUInt32(dataReader.GetOrdinal("numero"));
                        clienteArray.Complemento = dataReader.GetString(dataReader.GetOrdinal("complemento"));

                        clientesList.Add(clienteArray);
                    }

                    if (clientesList.Count() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        erro = "Existem " + clientesList.Count() + " valores com esse ID";
                        return false;
                    }
                }
                else
                {
                    erro = "Não Existe um valor com esse ID";
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
                op_database.Dispose();
            }
        }


        public Boolean InsertClientes(Clientes cliente)
        { 
            string querryInsert;

            querryInsert = string.Format("INSERT INTO clientes" +
                "(cpf, nome, cnh, num_tel, email, logradouro, numero, complemento) " +
                "values('{0}', '{1}', '{2}', {3}, '{4}', '{5}', {6}, '{7}');",
                cliente.Cpf, cliente.Nome, cliente.Cnh, cliente.NumeroTelefone, cliente.Email,
                cliente.Logradouro, cliente.NumeroEndereco, cliente.Complemento);

            try
            {
                op_database.ExecuteCommand(querryInsert);
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
                op_database.Dispose();
            }

        }


        public Boolean UpdateCliente(Clientes cliente)
        {

            string querryUpdate;

            querryUpdate = string.Format("UPDATE clientes SET " +
                "cpf='{0}', nome='{1}', cnh='{2}', " +
                "num_tel='{3}', email='{4}', logradouro='{5}', " +
                "numero='{6}', complemento=='{7}' " +
                "WHERE id_cli=='{8}'",
                cliente.Cpf, cliente.Nome, cliente.Cnh, cliente.NumeroTelefone, cliente.Email,
                cliente.Logradouro, cliente.NumeroEndereco, cliente.Complemento, cliente.Id);

            try
            {
                op_database.ExecuteCommand(querryUpdate);
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
                op_database.Dispose();
            }

        }


        public Boolean DeleteCliente(Clientes cliente)
        {
            string querryDelete = string.Format("DELETE FROM clientes WHERE id_cli={0}", cliente.Id);

            try
            {
                op_database.ExecuteCommand(querryDelete);
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
                op_database.Dispose();
            }

        }


        //Traz uma Lista de Todos os Veiculos
        public Boolean ListClientes()
        {
            string selectAll = "SELECT * FROM clientes";

            try { 
                //Armazena os dados obtidos
                MySqlDataReader dataReader;

                dataReader = op_database.returnCommand(selectAll);

                bool existRecord = false;

                existRecord = dataReader.HasRows;

                if (existRecord)
                {
                    while (dataReader.Read())
                    {
                        Clientes clienteArray = new Clientes();

                        clienteArray.Id = dataReader.GetUInt32(dataReader.GetOrdinal("id_cli"));
                        clienteArray.Cpf = dataReader.GetString(dataReader.GetOrdinal("cpf"));
                        clienteArray.Nome = dataReader.GetString(dataReader.GetOrdinal("nome"));
                        clienteArray.Cnh = dataReader.GetString(dataReader.GetOrdinal("cnh"));
                        clienteArray.NumeroTelefone = dataReader.GetUInt64(dataReader.GetOrdinal("num_tel"));
                        clienteArray.Email = dataReader.GetString(dataReader.GetOrdinal("email"));
                        clienteArray.Logradouro = dataReader.GetString(dataReader.GetOrdinal("logradouro"));
                        clienteArray.NumeroEndereco = dataReader.GetUInt32(dataReader.GetOrdinal("numero"));
                        clienteArray.Complemento = dataReader.GetString(dataReader.GetOrdinal("complemento"));

                        clientesList.Add(clienteArray);
                    }

                    op_database.Dispose();
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
                op_database.Dispose();
            }
        }


    }
}
