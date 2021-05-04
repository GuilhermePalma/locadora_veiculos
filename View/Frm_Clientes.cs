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
    public partial class Frm_Clientes : Form
    {
        public Frm_Clientes()
        {
            InitializeComponent();
        }


        private int id=-1, numeroTelefone=-1, numeroEndereco=-1;
        private string cpf = "", nome = "", cnh = "", email = "", logradouro = "", complemento = "";

       

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void Btn_listar_Click(object sender, EventArgs e)
        {
            //Metodo de Listar Veiculos no Form List
            Lists listClientes = new Lists();
            listClientes.ListClientes();
            listClientes.ShowDialog();
        }


        private void Btn_cadastro_Click(object sender, EventArgs e)
        {
            cpf = txt_cpf.Text;
            nome = txt_nome.Text;
            cnh = txt_cnh.Text;
            email = txt_email.Text;
            logradouro = txt_endereco.Text;
            complemento = txt_complemento.Text;

            try
            {
                id = Convert.ToInt32(txt_id.Text);
                numeroTelefone = Convert.ToInt32(txt_telefone.Text);
                numeroEndereco = Convert.ToInt32(txt_endereco.Text);
            }
            catch
            {
                MessageBox.Show("O Campo 'ID' ou 'Ano' ou 'N° Endereço' não Foi Preenchido");
            }


            if (cpf != "" && nome != "" && cnh != "" && email != "" && logradouro != ""
                && id != -1 && numeroTelefone != -1 && numeroEndereco != -1)
            {
                Clientes cliente = new Clientes(id, cpf, nome, cnh, numeroTelefone, email, logradouro, numeroEndereco, complemento);
                ClienteModel clienteModel = new ClienteModel();

                if (clienteModel.SelectClientesID(cliente))
                {
                    MessageBox.Show("Já existe um Cliente com esse ID!!!\n\nErro:\n" + clienteModel.erro);
                }
                else
                {
                    if (!clienteModel.InsertClientes(cliente))
                    {
                        MessageBox.Show("Não foi possivel Cadastrar o Cliente!!!\n\nErro:\n" + clienteModel.erro);
                    }
                    else
                    {
                        MessageBox.Show("Dados Cadastrados Com Sucesso!!!"
                            + "\nID_Cliente: " + cliente.Id
                            + "\nNome: " + cliente.Nome
                            + "\nCPF: " + cliente.Cpf
                            + "\nCNH: " + cliente.Cnh
                            + "\nTelefone: " + cliente.NumeroTelefone
                            + "\nE-mail: " + cliente.Email
                            + "\nLogradouro: " + cliente.Logradouro
                            + "\nN°: " + cliente.NumeroTelefone
                            + "\nComplemento: " + cliente.Complemento);

                        txt_id.Text = "";
                        txt_cpf.Text = "";
                        txt_nome.Text = "";
                        txt_cnh.Text = "";
                        txt_telefone.Text = "";
                        txt_email.Text = "";
                        txt_endereco.Text = "";
                        txt_numero.Text = "";
                        txt_complemento.Text = "";
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
            nome = txt_nome.Text;
            cnh = txt_cnh.Text;
            email = txt_email.Text;
            logradouro = txt_endereco.Text;
            complemento = txt_complemento.Text;

            try
            {
                id = Convert.ToInt32(txt_id.Text);
                numeroTelefone = Convert.ToInt32(txt_telefone.Text);
                numeroEndereco = Convert.ToInt32(txt_endereco.Text);
            }
            catch
            {
                MessageBox.Show("O Campo 'ID' ou 'Ano' ou 'N° Endereço' não Foi Preenchido");
            }

            if (cpf != "" && nome != "" && cnh != "" && email != "" && logradouro != "" &&
                id != -1 && numeroTelefone != -1 && numeroEndereco != -1)
            {
                Clientes cliente = new Clientes(id, cpf, nome, cnh, numeroTelefone, email, logradouro, numeroEndereco, complemento);
                ClienteModel clienteModel = new ClienteModel();

                if (!clienteModel.SelectClientesID(cliente))
                {
                    MessageBox.Show("Não foi possivel Localizar o ID do Cliente!!!\n\nErro:\n" + clienteModel.erro);
                }
                else
                {
                    if (!clienteModel.UpdateCliente(cliente))
                    {
                        MessageBox.Show("Não foi possivel Atualizar o Cliente!!!\n\nErro:\n" + clienteModel.erro);
                    }
                    else
                    {
                        MessageBox.Show("Dados Atualizados Com Sucesso !!!"
                            + "ID_Cliente: " + cliente.Id
                            + "\nNome: " + cliente.Nome
                            + "\nCPF: " + cliente.Cpf
                            + "\nCNH: " + cliente.Cnh
                            + "\nTelefone: " + cliente.NumeroTelefone
                            + "\nE-mail: " + cliente.Email
                            + "\nLogradouro: " + cliente.Logradouro
                            + "\nN°: " + cliente.NumeroTelefone
                            + "\nComplemento: " + cliente.Complemento);

                        txt_id.Text = "";
                        txt_cpf.Text = "";
                        txt_nome.Text = "";
                        txt_cnh.Text = "";
                        txt_telefone.Text = "";
                        txt_email.Text = "";
                        txt_endereco.Text = "";
                        txt_numero.Text = "";
                        txt_complemento.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira Os dados Corretamente!!!");
            }

        }


        private void Btn_excluir_Click(object sender, EventArgs e)
        {
            txt_cpf.Text = "";
            txt_nome.Text = "";
            txt_cnh.Text = "";
            txt_telefone.Text = "";
            txt_email.Text = "";
            txt_endereco.Text = "";
            txt_numero.Text = "";
            txt_complemento.Text = "";

            try
            {
                id = Convert.ToInt32(txt_id.Text);

                Clientes cliente = new Clientes(id, "","","",0,"","",0,"");
                ClienteModel clienteModel = new ClienteModel();

                if (!clienteModel.SelectClientesID(cliente))
                {
                    MessageBox.Show("Não foi possivel Localizar o ID do Cliente!!!\n\nErro:\n" + clienteModel.erro);
                }
                else
                {
                    if (!clienteModel.DeleteVeiculo(cliente))
                    {
                        MessageBox.Show("Não foi possivel Excluir o Cliente!!!\n\nErro:\n" + clienteModel.erro);
                    }
                    else
                    {
                        MessageBox.Show("Dados Excluidos Com Sucesso !!!\n ID_Cliente: " + cliente.Id);

                        txt_cpf.Text = "";
                        txt_nome.Text = "";
                        txt_cnh.Text = "";
                        txt_telefone.Text = "";
                        txt_email.Text = "";
                        txt_endereco.Text = "";
                        txt_numero.Text = "";
                        txt_complemento.Text = "";
                    }
                }
            }
            catch
            {
                MessageBox.Show("O Campo 'ID' não Foi Preenchido");
            }
        }



    }
}
