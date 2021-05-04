using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using locadora_veiculos.Controller;

namespace locadora_veiculos.Model
{
    class VeiculosModel
    {
        public string erro;
        public List<Veiculos> veiculosList = new List<Veiculos>();
        public int registrosAfetados;
        private Connection urlDB = new Connection();


        public Boolean SelectVeiculoID(Veiculos veiculo)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());

            MySqlCommand QuerrySelect = Connect.CreateCommand();
            QuerrySelect.CommandText = "SELECT * FROM veiculos WHERE id_veiculo=?id";

            QuerrySelect.Parameters.AddWithValue("?id", veiculo.Id);

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
                        Veiculos veiculosArray = new Veiculos();

                        veiculosArray.Id = dataReader.GetInt32(dataReader.GetOrdinal("id_veiculo"));
                        veiculosArray.Placa = dataReader.GetString(dataReader.GetOrdinal("placa"));
                        veiculosArray.Cidade = dataReader.GetString(dataReader.GetOrdinal("cidade_registro"));
                        veiculosArray.Placa_mercosul = dataReader.GetInt16(dataReader.GetOrdinal("placa_mercosul"));
                        veiculosArray.Modelo = dataReader.GetString(dataReader.GetOrdinal("modelo"));
                        veiculosArray.Marca = dataReader.GetString(dataReader.GetOrdinal("marca"));
                        veiculosArray.Cor = dataReader.GetString(dataReader.GetOrdinal("cor"));
                        veiculosArray.Ano = dataReader.GetInt32(dataReader.GetOrdinal("ano"));
                        veiculosArray.Status = dataReader.GetString(dataReader.GetOrdinal("status_veiculo"));

                        veiculosList.Add(veiculosArray);
                    }

                    if (veiculosList.Count() == 1)
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

        public Boolean InsertVeiculos(Veiculos veiculo) {

            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());
            MySqlCommand QuerryInsert = Connect.CreateCommand();

            QuerryInsert.CommandText = "INSERT INTO veiculos(placa, cidade_registro, " +
                "placa_mercosul, modelo, marca, cor, ano, status_veiculo) values(?placa, ?cidade_registro, " +
                "?placa_mercosul, ?modelo, ?marca, ?cor, ?ano, ?status_veiculo)";
            QuerryInsert.Parameters.AddWithValue("?placa", veiculo.Placa);
            QuerryInsert.Parameters.AddWithValue("?cidade_registro", veiculo.Cidade);
            QuerryInsert.Parameters.AddWithValue("?placa_mercosul", veiculo.Placa_mercosul);
            QuerryInsert.Parameters.AddWithValue("?modelo", veiculo.Modelo);
            QuerryInsert.Parameters.AddWithValue("?marca", veiculo.Marca);
            QuerryInsert.Parameters.AddWithValue("?cor", veiculo.Cor);
            QuerryInsert.Parameters.AddWithValue("?ano", veiculo.Ano);
            QuerryInsert.Parameters.AddWithValue("?status_veiculo", veiculo.Status);


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

        public Boolean UpdateVeiculo(Veiculos veiculo)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());
            MySqlCommand QuerryUpdate = Connect.CreateCommand();

            QuerryUpdate.CommandText = "UPDATE veiculos SET placa=?placa, cidade_registro=?cidade_registro, placa_mercosul=?placa_mercosul, " +
                "modelo=?modelo, marca=?marca, cor=?cor, ano=?ano, status_veiculo=?status_veiculo " +
                "WHERE id_veiculo=?id_veiculo";
            QuerryUpdate.Parameters.AddWithValue("?placa", veiculo.Placa);
            QuerryUpdate.Parameters.AddWithValue("?cidade_registro", veiculo.Cidade);
            QuerryUpdate.Parameters.AddWithValue("?placa_mercosul", veiculo.Placa_mercosul);
            QuerryUpdate.Parameters.AddWithValue("?modelo", veiculo.Modelo);
            QuerryUpdate.Parameters.AddWithValue("?marca", veiculo.Marca);
            QuerryUpdate.Parameters.AddWithValue("?cor", veiculo.Cor);
            QuerryUpdate.Parameters.AddWithValue("?ano", veiculo.Ano);
            QuerryUpdate.Parameters.AddWithValue("?status_veiculo", veiculo.Status);
            QuerryUpdate.Parameters.AddWithValue("?id_veiculo", veiculo.Id);

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

        public Boolean DeleteVeiculo(Veiculos veiculo)
        {
            MySqlConnection Connect = new MySqlConnection(urlDB.ExecuteConnection());
            MySqlCommand QuerryDelete = Connect.CreateCommand();

            QuerryDelete.CommandText = "DELETE FROM veiculos WHERE id_veiculo=?id_veiculo";
            QuerryDelete.Parameters.AddWithValue("?id_veiculo", veiculo.Id);

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
            QuerryAllSelect.CommandText = "SELECT * FROM veiculos";

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
                        Veiculos veiculosArray = new Veiculos(0, "", "", 0, "", "", "", 0, "");

                        veiculosArray.Id = dataReader.GetInt32(dataReader.GetOrdinal("id_veiculo"));
                        veiculosArray.Placa = dataReader.GetString(dataReader.GetOrdinal("placa"));
                        veiculosArray.Cidade = dataReader.GetString(dataReader.GetOrdinal("cidade_registro"));
                        veiculosArray.Placa_mercosul = dataReader.GetInt16(dataReader.GetOrdinal("placa_mercosul"));
                        veiculosArray.Modelo = dataReader.GetString(dataReader.GetOrdinal("modelo"));
                        veiculosArray.Marca = dataReader.GetString(dataReader.GetOrdinal("marca"));
                        veiculosArray.Cor = dataReader.GetString(dataReader.GetOrdinal("cor"));
                        veiculosArray.Ano = dataReader.GetInt32(dataReader.GetOrdinal("ano"));
                        veiculosArray.Status = dataReader.GetString(dataReader.GetOrdinal("status_veiculo"));

                        veiculosList.Add(veiculosArray);
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
