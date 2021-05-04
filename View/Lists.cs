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
    public partial class Lists : Form
    {
        public Lists()
        {
            InitializeComponent();
        }

        private void Lists_Load(object sender, EventArgs e)
        {

        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dgv_veiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ListVeiculos()
        {
            VeiculosModel listVeiculos = new VeiculosModel();

            dgv_list.DataSource = null; //Limpa o DataGridView
            lbl_op.Text = "Operações Veiculos";

            if (!listVeiculos.ListVeiculos())
            {
                MessageBox.Show("Não foi possivel Listar os Veiculos!!!\n\nErro:\n" + listVeiculos.erro);
            }
            else
            {
                dgv_list.DataSource = listVeiculos.veiculosList;

                dgv_list.Columns["Id"].HeaderText = "ID";
                dgv_list.Columns["Placa"].HeaderText = "Placa";
                dgv_list.Columns["Cidade"].HeaderText = "Cidade";
                dgv_list.Columns["Placa_mercosul"].HeaderText = "Mercosul";
                dgv_list.Columns["Modelo"].HeaderText = "Modelo";
                dgv_list.Columns["Marca"].HeaderText = "Marca";
                dgv_list.Columns["Cor"].HeaderText = "Cor";
                dgv_list.Columns["Ano"].HeaderText = "Ano";
                dgv_list.Columns["Status"].HeaderText = "Status";

                dgv_list.Columns[0].Width = 30;
                dgv_list.Columns[1].Width = 60;
                dgv_list.Columns[2].Width = 100;
                dgv_list.Columns[3].Width = 20;
                dgv_list.Columns[4].Width = 50;
                dgv_list.Columns[5].Width = 50;
                dgv_list.Columns[6].Width = 50;
                dgv_list.Columns[7].Width = 40;
                dgv_list.Columns[8].Width = 70;

                MessageBox.Show("Lista de dados dos Carros Concluida!!!");
            }
        }


        public void ListClientes()
        {
            ClienteModel listVeiculos = new ClienteModel();

            dgv_list.DataSource = null; //Limpa o DataGridView
            lbl_op.Text = "Operações Clientes";

            if (!listVeiculos.ListVeiculos())
            {
                MessageBox.Show("Não foi possivel Listar os Clientes!!!\n\nErro:\n" + listVeiculos.erro);
            }
            else
            {
                dgv_list.DataSource = listVeiculos.clientesList;

                dgv_list.Columns["Id"].HeaderText = "ID";
                dgv_list.Columns["Nome"].HeaderText = "Nome";
                dgv_list.Columns["Cpf"].HeaderText = "CPF";
                dgv_list.Columns["Cnh"].HeaderText = "CNH";
                dgv_list.Columns["NumeroTelefone"].HeaderText = "Telefone";
                dgv_list.Columns["Email"].HeaderText = "Email";
                dgv_list.Columns["Logradouro"].HeaderText = "Logradouro";
                dgv_list.Columns["NumeroEndereco"].HeaderText = "N°";
                dgv_list.Columns["Complemento"].HeaderText = "Complemento";

                dgv_list.Columns[0].Width = 30;
                dgv_list.Columns[1].Width = 100;
                dgv_list.Columns[2].Width = 80;
                dgv_list.Columns[3].Width = 80;
                dgv_list.Columns[4].Width = 80;
                dgv_list.Columns[5].Width = 80;
                dgv_list.Columns[6].Width = 80;
                dgv_list.Columns[7].Width = 50;
                dgv_list.Columns[8].Width = 70;

                MessageBox.Show("Lista de dados dos Clientes Concluida!!!");
            }
        }

        public void ListLocacoes()
        {
            LocacoesModel listVeiculos = new LocacoesModel();

            dgv_list.DataSource = null; //Limpa o DataGridView
            lbl_op.Text = "Operações Locações";

            if (!listVeiculos.ListVeiculos())
            {
                MessageBox.Show("Não foi possivel Listar as Locações!!!\n\nErro:\n" + listVeiculos.erro);
            }
            else
            {

                dgv_list.DataSource = listVeiculos.locacoesList;

                dgv_list.Columns["Id_locacao"].HeaderText = "ID";
                dgv_list.Columns["Cpf"].HeaderText = "CPF";
                dgv_list.Columns["Placa"].HeaderText = "Placa";
                dgv_list.Columns["Valor_locacao"].HeaderText = "Valor/dia";
                dgv_list.Columns["Data_retirada"].HeaderText = "Data Retirada";
                dgv_list.Columns["Data_entrega"].HeaderText = "Data Entrega";

                dgv_list.Columns[0].Width = 30;
                dgv_list.Columns[1].Width = 80;
                dgv_list.Columns[2].Width = 80;
                dgv_list.Columns[3].Width = 80;
                dgv_list.Columns[4].Width = 80;
                dgv_list.Columns[5].Width = 80;

                MessageBox.Show("Lista de dados dos Locações Concluida!!!");
            }
        }


        private void BtnFechar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
