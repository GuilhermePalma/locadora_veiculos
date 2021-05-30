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


        private ulong numeroTelefone;
        private uint id, numeroEndereco;
        private string cpf = "", nome = "", cnh = "", email = "", logradouro = "", complemento = "";
        private bool integerTrue = false;

        //Recupera as Infromações dos Inputs, Valida se foram preenchidos corretamente
        private Boolean RecoveryValues()
        {
            cpf = txt_cpf.Text;
            nome = txt_nome.Text;
            cnh = txt_cnh.Text;
            email = txt_email.Text;
            logradouro = txt_endereco.Text;
            complemento = txt_complemento.Text;

            try
            {
                id = uint.Parse(txt_id.Text);
                numeroTelefone = ulong.Parse(txt_telefone.Text);
                numeroEndereco = uint.Parse(txt_numero.Text);
                integerTrue = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Insira somente valores Inteiros Positivos nos campos 'Id', 'Telefone' e 'Numero'");
                return false;
            }


            if (cpf != "" && nome != ""
               && cnh != "" && email != ""
               && logradouro != ""
               && integerTrue != false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Limpa os Inputs do Formulario
        private void ClearInputs()
        {
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
       

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        //Metodo de Listar Clientes no Form List
        private void Btn_listar_Click(object sender, EventArgs e)
        {
            ClearInputs();
            //Instancia o Formulario
            Frm_Lists listClientes = new Frm_Lists();
            //Chama o Metodo ListClientes() do Frm_Clientes
            listClientes.ListClientes();
            //Mostra o Forms na tela
            listClientes.ShowDialog();
        }


        //Cadastra Clientes
        private void Btn_cadastro_Click(object sender, EventArgs e)
        {
            //Valida os Valores dos Inputs
            if (RecoveryValues() == true)
            {
                Clientes cliente = new Clientes(id, cpf, nome, cnh, numeroTelefone, email, 
                    logradouro, numeroEndereco, complemento);

                ClienteDAO clienteDAO = new ClienteDAO();

                //Verifica se já existe o Cliente
                if (clienteDAO.SelectClientesID(cliente))
                {
                    MessageBox.Show("Já existe um Cliente com esse ID!!!\n\nErro:\n" + clienteDAO.erro);
                }
                else
                {
                    //Tenta fazer o Insert no Banco de Dados
                    if (clienteDAO.InsertClientes(cliente))
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

                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel Cadastrar o Cliente!!!\n\nErro:\n" + clienteDAO.erro);
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira Todos os Dados !!!");
            }
        }

        //Altera Clientes
        private void Btn_alterar_Click(object sender, EventArgs e)
        {
            //Valida os Valores dos Inputs
            if (RecoveryValues() == true)
            {
                Clientes cliente = new Clientes(id, cpf, nome, cnh, numeroTelefone, email,
                    logradouro, numeroEndereco, complemento);
                ClienteDAO clienteDAO = new ClienteDAO();

                //Verifica se existe um Cliente com aquela ID
                if (clienteDAO.SelectClientesID(cliente))
                {
                    //Tenta atualizar o Cliente
                    if (clienteDAO.UpdateCliente(cliente))
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

                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel Atualizar o Cliente!!!\n\nErro:\n" + clienteDAO.erro);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel Localizar o ID do Cliente!!!\n\nErro:\n" + clienteDAO.erro);
                }
            }
            else
            {
                MessageBox.Show("Insira Os dados Corretamente!!!");
            }
            
        }


        private void Btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Tenta recuperar se foi inserido um valor no Input ID
                id = uint.Parse(txt_id.Text);

                Clientes cliente = new Clientes(id, "", "", "", 0, "", "", 0, "");
                ClienteDAO clienteDAO = new ClienteDAO();

                //Verifica se existe um cliente com aquele ID
                if (clienteDAO.SelectClientesID(cliente))
                {
                    //Tenta exlcluir o Cliente
                    if (clienteDAO.DeleteCliente(cliente))
                    {
                        MessageBox.Show("Dados Excluidos Com Sucesso !!!\n ID_Cliente: " + cliente.Id);
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel Excluir o Cliente!!!\n\nErro:\n" + clienteDAO.erro);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel Localizar o ID do Cliente!!!\n\nErro:\n" + clienteDAO.erro);
                }
            }
            catch
            {
                MessageBox.Show("Insira valores Inteiros Positivos nos campo 'Id'");
            }

        }



    }
}
