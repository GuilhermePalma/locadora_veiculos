using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using locadora_veiculos.View;

namespace locadora_veiculos
{
    public partial class Index : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private bool i = false;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Index()
        {
            InitializeComponent();
        }

        public void PanelForm<Forms1>() where Forms1 : Form, new()
        {
            Form formulario;
            formulario = panel_lateral.Controls.OfType<Forms1>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Forms1();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panel_conteudo.Controls.Add(formulario);
                panel_conteudo.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestourer.Visible = true;
        }
        private void Teste24_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void panelCabecalho_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panelCabecalho_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            if (i)
            {
                i = false;
                panel_conteudo.Controls.Clear();
            }
            else
            {
                i = true;
                PanelForm<Frm_Locacoes>();
            }
        }

        private void Btn_opVeiculos_Click(object sender, EventArgs e)
        {
            if (i)
            {
                i = false;
                panel_conteudo.Controls.Clear();
            }
            else
            {
                i = true;
                PanelForm<Frm_Veiculos>();
            }
        }
        private void Btn_opClientes_Click(object sender, EventArgs e)
        {
            if (i)
            {
                i = false;
                panel_conteudo.Controls.Clear();
            }
            else
            {
                i = true;
                PanelForm<Frm_Clientes>();
            }
        }

        private void BtnRestourer_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestourer.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelConteudo_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Button5_Click(object sender, EventArgs e)
        {
            if (i)
            {
                i = false;
                panel_conteudo.Controls.Clear();
            }
            else
            {
                i = true;
                PanelForm<Frm_Locacoes>();
            }
        }


    }
}
