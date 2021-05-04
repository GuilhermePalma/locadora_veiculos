using locadora_veiculos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace locadora_veiculos
{
    public partial class Frm_Veiculos : Form
    {
        private string placa = "", cidade = "", modelo = "", marca = "", cor = "", status = "";
        private int id = -1, ano = -1, placa_mercosul = 0;

        public int Resultados { get; private set; }

        public Frm_Veiculos()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Btn_alterar_Click(object sender, EventArgs e)
        {
            placa = txt_placa.Text;
            cidade = txt_cidade.Text;
            modelo = txt_modelo.Text;
            marca = txt_marca.Text;
            cor = txt_cor.Text;
            status = cmb_status.Text;

            try
            {
                id = Convert.ToInt32(txt_id.Text);
                ano = Convert.ToInt32(txt_ano.Text);
            }
            catch
            {
                MessageBox.Show("O Campo 'ID' ou 'Ano' não Foi Preenchido");
            }

            if (radbtn_brasil.Checked)
            {
                placa_mercosul = 0;
            }
            else if (radbtn_mercosul.Checked)
            {
                placa_mercosul = 1;
            }
            else
            {
                MessageBox.Show("Selecione o Modelo da Placa");
            }


            if (placa != "" && cidade != "" && modelo != "" && marca != "" && cor != "" &&
                status != "" && id != -1 && ano != -1)
            {

                Model.Veiculos veiculo = new Model.Veiculos(id, placa, cidade, placa_mercosul, modelo,
                    marca, cor, ano, status);
                VeiculosModel veiculosModel = new VeiculosModel();

                if (!veiculosModel.SelectVeiculoID(veiculo))
                {
                    MessageBox.Show("Não foi possivel Localizar o ID do Veiculo!!!\n\nErro:\n" + veiculosModel.erro);
                }
                else
                {
                    if (!veiculosModel.UpdateVeiculo(veiculo))
                    {
                        MessageBox.Show("Não foi possivel Atualizar o Veiculo!!!\n\nErro:\n" + veiculosModel.erro);
                    }
                    else
                    {
                        MessageBox.Show("Dados Atualizados Com Sucesso !!!");

                        MessageBox.Show("Id_Veiculo: " + veiculo.Id
                            + "\nNovos Dados:"
                            + "\nPlaca: " + veiculo.Placa
                            + "\nCidade: " + veiculo.Cidade
                            + "\nPlaca Mercosul: " + veiculo.Placa_mercosul
                            + "\nModelo: " + veiculo.Modelo
                            + "\nMarca: " + veiculo.Marca
                            + "\nCor: " + veiculo.Cor
                            + "\nAno: " + veiculo.Ano
                            + "\nStatus: " + veiculo.Status);

                        txt_placa.Text = "";
                        txt_cidade.Text = "";
                        txt_modelo.Text = "";
                        txt_marca.Text = "";
                        txt_cor.Text = "";
                        cmb_status.Text = "";
                        txt_id.Text = "";
                        txt_ano.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira Os dados Corretamente!!!");
            }

        }

        private void Btm_cadastrar_Click(object sender, EventArgs e)
        {
            placa = txt_placa.Text;
            cidade = txt_cidade.Text;
            modelo = txt_modelo.Text;
            marca = txt_marca.Text;
            cor = txt_cor.Text;
            status = cmb_status.Text;

            try
            {
                id = Convert.ToInt32(txt_id.Text);
                ano = Convert.ToInt32(txt_ano.Text);
            }
            catch
            {
                MessageBox.Show("O Campo 'ID' ou 'Ano' não Foi Preenchido");
            }

            if (radbtn_brasil.Checked)
            {
                placa_mercosul = 0;
            }
            else if (radbtn_mercosul.Checked)
            {
                placa_mercosul = 1;
            }
            else
            {
                MessageBox.Show("Selecione o Modelo da Placa");
            }


            if (placa != null && cidade != "" && modelo != "" && marca != "" && cor != "" &&
                status != "" && id != -1 && ano != -1)
            {
                Model.Veiculos veiculo = new Model.Veiculos(id, placa, cidade, placa_mercosul, modelo,
                   marca, cor, ano, status);
                VeiculosModel veiculosModel = new VeiculosModel();

                if (veiculosModel.SelectVeiculoID(veiculo))
                {
                    MessageBox.Show("Já existe um Veiculo com esse ID!!!\n\nErro:\n" + veiculosModel.erro);
                }
                else
                {
                    if (!veiculosModel.InsertVeiculos(veiculo))
                    {
                        MessageBox.Show("Não foi possivel Cadastrar o Veiculo!!!\n\nErro:\n" + veiculosModel.erro);
                    }
                    else
                    {
                        MessageBox.Show("Dados Cadastrados Com Sucesso!!!" 
                            + "Id_Veiculo: " + veiculo.Id
                            + "\nPlaca: " + veiculo.Placa
                            + "\nCidade: " + veiculo.Cidade
                            + "\nPlaca Mercosul: " + veiculo.Placa_mercosul
                            + "\nModelo: " + veiculo.Modelo
                            + "\nMarca: " + veiculo.Marca
                            + "\nCor: " + veiculo.Cor
                            + "\nAno: " + veiculo.Ano
                            + "\nStatus: " + veiculo.Status);

                        txt_placa.Text = "";
                        txt_cidade.Text = "";
                        txt_modelo.Text = "";
                        txt_marca.Text = "";
                        txt_cor.Text = "";
                        cmb_status.Text = "";
                        txt_id.Text = "";
                        txt_ano.Text = "";
                    }

                }
            }
            else
            {
                MessageBox.Show("Insira Todos os Dados !!!");
            }
        }

        private void Btn_excluir_Click(object sender, EventArgs e)
        {
            txt_placa.Text = "";
            txt_cidade.Text = "";
            txt_modelo.Text = "";
            txt_marca.Text = "";
            txt_cor.Text = "";
            cmb_status.Text = "";

            try
            {
                id = Convert.ToInt32(txt_id.Text);

                Veiculos veiculo = new Veiculos(id,"","",0,"","","",0,"");
                VeiculosModel veiculosModel = new VeiculosModel();

                if (!veiculosModel.SelectVeiculoID(veiculo))
                {
                    MessageBox.Show("Não foi possivel Localizar o ID do Veiculo!!!\n\nErro:\n" + veiculosModel.erro);
                }
                else
                {
                    if (!veiculosModel.DeleteVeiculo(veiculo))
                    {
                        MessageBox.Show("Não foi possivel Excluir o Veiculo!!!\n\nErro:\n" + veiculosModel.erro);
                    }
                    else
                    {
                        MessageBox.Show("Dados Excluidos Com Sucesso !!!\n ID_Veiculo: " + veiculo.Id);
                        txt_placa.Text = "";
                        txt_cidade.Text = "";
                        txt_modelo.Text = "";
                        txt_marca.Text = "";
                        txt_cor.Text = "";
                        cmb_status.Text = "";
                    }
                }

            }
            catch
            {
                MessageBox.Show("O Campo 'ID' não Foi Preenchido");
            }

        }

        private void Btn_listar_Click(object sender, EventArgs e)
        {
            //Metodo de Listar Veiculos no Form List
            Lists listVeiculos = new Lists();
            listVeiculos.ListVeiculos();
            listVeiculos.ShowDialog();
        }

    }
}
