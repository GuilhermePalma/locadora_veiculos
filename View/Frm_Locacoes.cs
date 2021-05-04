using locadora_veiculos.Model;
using locadora_veiculos.Model.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace locadora_veiculos.View
{
    public partial class Frm_Locacoes : Form
    {
        public Frm_Locacoes()
        {
            InitializeComponent();
        }

        private string cpf = "", placa = "", dt_retirada = "", dt_entrega = "";
        private double valor_locacao = -1, taxa = 0.08, valor = 0, valorAtraso;
        private int id_locacao = -1;
        private DateTime data_retirada = Convert.ToDateTime("01/01/0001");
        private DateTime data_entrega = Convert.ToDateTime("01/01/0001");
        private DateTime data_entregaOf = Convert.ToDateTime("01/01/0001");
        TimeSpan qnt_dias = new TimeSpan();

        private void Mtb_dtentrega_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Frm_Locacoes_Load(object sender, EventArgs e)
        {

        }

        private void Btn_devolver_Click(object sender, EventArgs e)
        {
            cpf = txt_cpf.Text;
            placa = txt_placa.Text;

            try
            {
                data_entrega = Convert.ToDateTime(mtb_dtentrega.Text);
                data_retirada = Convert.ToDateTime(mtb_dtretirada.Text);
                valor_locacao = Convert.ToDouble(mtb_preco.Text);
            }
            catch
            {
                MessageBox.Show("Insira os Dados.");
            }

            dt_entrega = data_entrega.ToString("yyyy/MM/dd");
            dt_retirada = data_retirada.ToString("yyyy/MM/dd");


            if (cpf != "" && placa != "" && dt_entrega != "0001/01/01" && dt_retirada != "0001/01/01"
                && valor_locacao != -1)
            {
                Locacoes locacoes = new Locacoes(id_locacao, cpf, placa, valor_locacao, data_retirada, data_entrega);
                LocacoesModel locacoesModel = new LocacoesModel();

                if (!locacoesModel.SelectLocacoesCpf(locacoes))
                {
                    MessageBox.Show("Não existe uma locação nesse CPF de Cliente!!!\n\nErro:\n" + locacoesModel.erro);
                }
                else
                {
                    if (!locacoesModel.SelectLocacoesPlaca(locacoes))
                    {
                        MessageBox.Show("Não existe uma locação nessa Placa do Veiculo!!!\n\nErro:\n" + locacoesModel.erro);
                    }
                    else
                    {

                        if (!locacoesModel.DeleteLocacaoPlaca(locacoes))
                        {
                            MessageBox.Show("Não foi possivel Devolver o Veiculo!!!\n\nErro:\n" + locacoesModel.erro);
                        }
                        else
                        {
                            valor_locacao = locacoesModel.valor_locacaoDB;
                            data_retirada = locacoesModel.dt_retiradaDB;
                            data_entregaOf = locacoesModel.dt_entregaDB;

                            if (data_entrega == data_entregaOf)
                            {
                                qnt_dias = data_entrega - data_retirada;
                                valor = qnt_dias.Days * valor_locacao;
                            }
                            else
                            {
                                qnt_dias = data_entrega - data_retirada;
                                valor = qnt_dias.Days * valor_locacao;
                                qnt_dias = data_entrega - data_entregaOf;
                                valorAtraso = valor_locacao * taxa * qnt_dias.Days;
                                valor = valorAtraso + valor;
                            }

                            MessageBox.Show("Valor Final: " + valor);

                            MessageBox.Show("Valor Final: " + valor
                                + "\nDados Selecionados:"
                                + "\nId_Locação: " + locacoes.Id_locacao
                                + "\nPlaca: " + locacoes.Placa
                                + "\nCPF: " + locacoes.Cpf
                                + "\nPreço: " + locacoes.Valor_locacao
                                + "\nData Retirada: " + locacoes.Data_retirada
                                + "\nData Entrega: " + locacoes.Data_entrega);

                            MessageBox.Show("Veiculo Devolvido Com Sucesso !!!"
                                + "\nDados do Veiculo Devolvido:"
                                + "\nValor Final: " + valor
                                + "\nPlaca: " + locacoes.Placa
                                + "\nCPF: " + locacoes.Cpf
                                + "\nPreço: " + locacoes.Valor_locacao
                                + "\nData Retirada: " + locacoes.Data_retirada
                                + "\nData Entrega: " + locacoes.Data_entrega);

                            txt_id.Text = "";
                            txt_cpf.Text = "";
                            txt_placa.Text = "";
                            mtb_preco.Text = "";
                            mtb_dtretirada.Text = "";
                            mtb_dtentrega.Text = "";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira Todos os Dados !!!");
            }

        }

        private void Btn_listar_Click(object sender, EventArgs e)
        {
            //Metodo de Listar Veiculos no Form List
            Lists listLocacoes = new Lists();
            listLocacoes.ListLocacoes();
            listLocacoes.ShowDialog();
        }

        private void Btn_alugar_Click(object sender, EventArgs e)
        {
            cpf = txt_cpf.Text;
            placa = txt_placa.Text;

            try
            {
                data_entrega = Convert.ToDateTime(mtb_dtentrega.Text);
                data_retirada = Convert.ToDateTime(mtb_dtretirada.Text);
                valor_locacao = Convert.ToDouble(mtb_preco.Text);
            }
            catch
            {
                MessageBox.Show("Insira os Dados.");
            }

            dt_entrega = data_entrega.ToString("yyyy/MM/dd");
            dt_retirada = data_retirada.ToString("yyyy/MM/dd");
            

            if (cpf != "" && placa != "" && dt_entrega != "0001/01/01" && dt_retirada != "0001/01/01"
                && valor_locacao != -1)
            { 
                Locacoes locacoes = new Locacoes(id_locacao, cpf, placa, valor_locacao, data_retirada, data_entrega);
                LocacoesModel locacoesModel = new LocacoesModel();

                if (locacoesModel.SelectLocacoesCpf(locacoes))
                {
                    MessageBox.Show("Já existe uma locação nesse ID de Cliente!!!\n\nErro:\n" + locacoesModel.erro);
                }
                else
                {
                    if (locacoesModel.SelectLocacoesPlaca(locacoes))
                    {
                        MessageBox.Show("Já existe uma locação nessa Placa do Veiculo!!!\n\nErro:\n" + locacoesModel.erro);
                    }
                    else
                    {

                        if (!locacoesModel.InsertLocacao(locacoes))
                        {
                            MessageBox.Show("Não foi possivel Cadastrar o Veiculo!!!\n\nErro:\n" + locacoesModel.erro);
                        }
                        else
                        {
                            MessageBox.Show("Dados Inseridos Com Sucesso !!!");

                            MessageBox.Show("\nDados Inseridos:"
                                + "\nPlaca: " + locacoes.Placa
                                + "\nCPF: " + locacoes.Cpf
                                + "\nPreço: " + locacoes.Valor_locacao
                                + "\nData Retirada: " + locacoes.Data_retirada
                                + "\nData Entrega: " + locacoes.Data_entrega);

                            txt_id.Text = "";
                            txt_cpf.Text = "";
                            txt_placa.Text = "";
                            mtb_preco.Text = "";
                            mtb_dtretirada.Text = "";
                            mtb_dtentrega.Text = "";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira Todos os Dados !!!");
            }
        }

        private void Btn_alterar_Click(object sender, EventArgs e)
        {
            cpf = txt_cpf.Text;
            placa = txt_placa.Text;

            try
            {
                data_entrega = Convert.ToDateTime(mtb_dtentrega.Text);
                data_retirada = Convert.ToDateTime(mtb_dtretirada.Text);
                valor_locacao = Convert.ToDouble(mtb_preco.Text);
                id_locacao = Convert.ToInt32(txt_id.Text);
            }
            catch
            {
                MessageBox.Show("Insira os Dados.");
            }

            dt_entrega = data_entrega.ToString("yyyy/MM/dd");
            dt_retirada = data_retirada.ToString("yyyy/MM/dd");


            if (cpf != "" && placa != "" && dt_entrega != "0001/01/01" && dt_retirada != "0001/01/01"
                && valor_locacao != -1)
            {
                Locacoes locacoes = new Locacoes(id_locacao, cpf, placa, valor_locacao, data_retirada, data_entrega);
                LocacoesModel locacoesModel = new LocacoesModel();

                if (locacoesModel.SelectLocacoesCpf(locacoes))
                {
                    MessageBox.Show("Já existe uma locação nesse ID de Cliente!!!\n\nErro:\n" + locacoesModel.erro);
                }
                else
                {
                    if (locacoesModel.SelectLocacoesPlaca(locacoes))
                    {
                        MessageBox.Show("Já existe uma locação nessa Placa de Veiculo!!!\n\nErro:\n" + locacoesModel.erro);
                    }
                    else
                    {

                        if (!locacoesModel.UpdateLocacao(locacoes))
                        {
                            MessageBox.Show("Não foi possivel Atualizar o Veiculo!!!\n\nErro:\n" + locacoesModel.erro);
                        }
                        else
                        {
                            MessageBox.Show("Dados Atualizados Com Sucesso !!!");

                            MessageBox.Show("\nID: " + locacoes.Cpf 
                                + "\nDados Atualizados:"
                                + "\nPlaca: " + locacoes.Placa
                                + "\nCPF: " + locacoes.Cpf
                                + "\nPreço: " + locacoes.Valor_locacao
                                + "\nData Retirada: " + locacoes.Data_retirada
                                + "\nData Entrega: " + locacoes.Data_entrega);

                            txt_id.Text = "";
                            txt_cpf.Text = "";
                            txt_placa.Text = "";
                            mtb_preco.Text = "";
                            mtb_dtretirada.Text = "";
                            mtb_dtentrega.Text = "";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira Todos os Dados !!!");
            }


            /*  cpf = txt_cpf.Text;
              placa = txt_placa.Text;
              data_retirada = mtb_dtretirada.Text;
              data_entrega = mtb_dtentrega.Text;

              try
              {
                  id_locacao = Convert.ToInt32(txt_id.Text);
                  valor_locacao = Convert.ToInt32(mtb_preco.Text);
              }
              catch
              {
                  MessageBox.Show("O Campo 'ID' e 'Dados de Locação) não Foi Preenchido");
              }

              if (cpf != "" && placa != "" && id_locacao != -1 && valor_locacao != -1 &&
                  data_retirada != "" && data_entrega != "")
              {
                  Locacoes locacoes = new Locacoes(id_locacao, cpf, placa, valor_locacao, data_retirada, data_entrega);
                  LocacoesModel locacoesModel = new LocacoesModel();

                  if (!locacoesModel.SelectLocacoesCpf(locacoes))
                  {
                      MessageBox.Show("Não foi possivel Localizar o ID do Cliente!!!\n\nErro:\n" + locacoesModel.erro);
                  }
                  else
                  {
                      if (!locacoesModel.SelectLocacoesPlaca(locacoes))
                      {
                          MessageBox.Show("Não foi possivel Localizar a Placa do Veiculo!!!\n\nErro:\n" + locacoesModel.erro);
                      }
                      else
                      {
                          if (!locacoesModel.UpdateLocacao(locacoes))
                          {
                              MessageBox.Show("Não foi possivel Atualizar A Locação!!!\n\nErro:\n" + locacoesModel.erro);
                          }
                          else
                          {
                              MessageBox.Show("Dados Atualizados Com Sucesso !!!");

                              MessageBox.Show("Id_Locação: " + locacoes.Id_locacao
                                  + "\nNovos Dados:"
                                  + "\nPlaca: " + locacoes.Placa
                                  + "\nCPF: " + locacoes.Cpf
                                  + "\nPreço: " + locacoes.Valor_locacao
                                  + "\nData Retirada: " + locacoes.Data_retirada
                                  + "\nData Entrega: " + locacoes.Data_entrega);

                              txt_id.Text = "";
                              txt_cpf.Text ="";
                              txt_placa.Text = "";
                              mtb_preco.Text = "";
                              mtb_dtretirada.Text = "";
                              mtb_dtentrega.Text = "";
                          }

                      }
                  }
              }
              else
              {
                  MessageBox.Show("Insira Os dados Corretamente!!!");
              }*/
        }

    }
}
