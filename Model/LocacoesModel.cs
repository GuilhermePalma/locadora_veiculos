using locadora_veiculos.Controller;
using locadora_veiculos.Model.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_veiculos.Model
{
    class LocacoesModel
    {
        public string erro;
        public List<Locacoes> locacoesList = new List<Locacoes>();
        public int registrosAfetados;
        public double valor_locacaoDB;
        public DateTime dt_retiradaDB, dt_entregaDB;
        private Connection urlDB = new Connection();


        public Boolean SelectLocacoesCpf(Locacoes locacoes)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());

            MySqlCommand QuerrySelect = Connect.CreateCommand();
            QuerrySelect.CommandText = "SELECT id_locacao, cpf, placa, valor_locacao, data_retirada, data_entrega " +
                "FROM locacoes WHERE cpf=?cpf";

            QuerrySelect.Parameters.AddWithValue("?cpf", locacoes.Cpf);

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
                        Locacoes locacoesArray = new Locacoes();

                        locacoesArray.Id_locacao = dataReader.GetInt32(dataReader.GetOrdinal("id_locacao"));
                        locacoesArray.Cpf = dataReader.GetString(dataReader.GetOrdinal("cpf"));
                        locacoesArray.Placa = dataReader.GetString(dataReader.GetOrdinal("placa"));
                        valor_locacaoDB = dataReader.GetDouble(dataReader.GetOrdinal("valor_locacao"));
                        dt_retiradaDB = dataReader.GetDateTime(dataReader.GetOrdinal("data_retirada"));
                        dt_entregaDB = dataReader.GetDateTime(dataReader.GetOrdinal("data_entrega"));

                        locacoesList.Add(locacoesArray);
                    }
                    return true;
                }
                else
                {
                    erro = "Não Existe de um valor com esse CPF";
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


        public Boolean SelectLocacoesPlaca(Locacoes locacoes)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());

            MySqlCommand QuerrySelect = Connect.CreateCommand();
            QuerrySelect.CommandText = "SELECT * FROM locacoes WHERE placa=?placa";

            QuerrySelect.Parameters.AddWithValue("?placa", locacoes.Placa);

            try
            {
                Connect.Open();
                //N° de linhas afetadas
                QuerrySelect.ExecuteNonQuery();

                //Armazena os dados obtidos
                MySqlDataReader dataReader;
                dataReader = QuerrySelect.ExecuteReader();

                bool existRecord = false;
                existRecord = dataReader.HasRows;

                if (existRecord)
                {
                   return true;
                }
                else
                {
                    erro = "Não Existe de um valor com esse CPF";
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


        public Boolean InsertLocacao(Locacoes locacoes)
        {

            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());
            MySqlCommand QuerryInsert = Connect.CreateCommand();


            QuerryInsert.CommandText = "INSERT INTO locacoes(cpf, placa, valor_locacao, " +
                "data_retirada, data_entrega) values(?cpf, ?placa, ?valor_locacao, " +
                "?data_retirada, ?data_entrega)";

            QuerryInsert.Parameters.AddWithValue("?cpf", locacoes.Cpf);
            QuerryInsert.Parameters.AddWithValue("?placa", locacoes.Placa);
            QuerryInsert.Parameters.AddWithValue("?valor_locacao", locacoes.Valor_locacao);
            QuerryInsert.Parameters.AddWithValue("?data_retirada", locacoes.Data_retirada);
            QuerryInsert.Parameters.AddWithValue("?data_entrega", locacoes.Data_entrega);


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


        public Boolean UpdateLocacao(Locacoes locacoes)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());
            MySqlCommand QuerryUpdate = Connect.CreateCommand();

            QuerryUpdate.CommandText = "UPDATE locacoes SET cpf=?cpf, placa=?placa, " +
                "valor_locacao=?valor_locacao, data_retirada=?data_retirada " +
                "WHERE id_locacao=?id_locacao";

            QuerryUpdate.Parameters.AddWithValue("?cpf", locacoes.Cpf);
            QuerryUpdate.Parameters.AddWithValue("?placa", locacoes.Placa);
            QuerryUpdate.Parameters.AddWithValue("?valor_locacao", locacoes.Valor_locacao);
            QuerryUpdate.Parameters.AddWithValue("?data_retirada", locacoes.Data_retirada);
            QuerryUpdate.Parameters.AddWithValue("?data_entrega", locacoes.Data_entrega);

            QuerryUpdate.Parameters.AddWithValue("?id_locacao", locacoes.Id_locacao);

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


        public Boolean DeleteLocacaoPlaca(Locacoes locacoes)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());
            MySqlCommand QuerryDelete = Connect.CreateCommand();

            QuerryDelete.CommandText = "DELETE FROM locacoes WHERE placa =?placa";
            QuerryDelete.Parameters.AddWithValue("?placa", locacoes.Placa);

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
            QuerryAllSelect.CommandText = "SELECT id_locacao,cpf,placa,valor_locacao,data_retirada,data_entrega " +
                "FROM locacoes";

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
                        Locacoes locacoesArray = new Locacoes();

                        locacoesArray.Id_locacao = dataReader.GetInt32(dataReader.GetOrdinal("id_locacao"));
                        locacoesArray.Cpf = dataReader.GetString(dataReader.GetOrdinal("cpf"));
                        locacoesArray.Placa = dataReader.GetString(dataReader.GetOrdinal("placa"));
                        locacoesArray.Valor_locacao = dataReader.GetInt32(dataReader.GetOrdinal("valor_locacao"));
                        locacoesArray.Data_retirada = dataReader.GetDateTime(dataReader.GetOrdinal("data_retirada"));
                        locacoesArray.Data_entrega = dataReader.GetDateTime(dataReader.GetOrdinal("data_entrega"));


                        locacoesList.Add(locacoesArray);
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
