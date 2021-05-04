namespace locadora_veiculos.View
{
    partial class Frm_Locacoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_listar = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.btn_devolver = new System.Windows.Forms.Button();
            this.btn_alugar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mtb_dtentrega = new System.Windows.Forms.MaskedTextBox();
            this.mtb_dtretirada = new System.Windows.Forms.MaskedTextBox();
            this.mtb_preco = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_placa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cpf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.lbl_devolver = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_listar
            // 
            this.btn_listar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_listar.Font = new System.Drawing.Font("Bahnschrift", 11.25F);
            this.btn_listar.Location = new System.Drawing.Point(370, 269);
            this.btn_listar.Name = "btn_listar";
            this.btn_listar.Size = new System.Drawing.Size(106, 45);
            this.btn_listar.TabIndex = 22;
            this.btn_listar.Text = "Listar";
            this.btn_listar.UseVisualStyleBackColor = true;
            this.btn_listar.Click += new System.EventHandler(this.Btn_listar_Click);
            // 
            // btn_alterar
            // 
            this.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_alterar.Font = new System.Drawing.Font("Bahnschrift", 11.25F);
            this.btn_alterar.Location = new System.Drawing.Point(251, 269);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(106, 45);
            this.btn_alterar.TabIndex = 21;
            this.btn_alterar.Text = "Aletrar";
            this.btn_alterar.UseVisualStyleBackColor = true;
            this.btn_alterar.Click += new System.EventHandler(this.Btn_alterar_Click);
            // 
            // btn_devolver
            // 
            this.btn_devolver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_devolver.Font = new System.Drawing.Font("Bahnschrift", 11.25F);
            this.btn_devolver.Location = new System.Drawing.Point(134, 270);
            this.btn_devolver.Name = "btn_devolver";
            this.btn_devolver.Size = new System.Drawing.Size(106, 45);
            this.btn_devolver.TabIndex = 20;
            this.btn_devolver.Text = "Devolver";
            this.btn_devolver.UseVisualStyleBackColor = true;
            this.btn_devolver.Click += new System.EventHandler(this.Btn_devolver_Click);
            // 
            // btn_alugar
            // 
            this.btn_alugar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_alugar.Font = new System.Drawing.Font("Bahnschrift", 11.25F);
            this.btn_alugar.Location = new System.Drawing.Point(18, 269);
            this.btn_alugar.Name = "btn_alugar";
            this.btn_alugar.Size = new System.Drawing.Size(106, 45);
            this.btn_alugar.TabIndex = 19;
            this.btn_alugar.Text = "Alugar";
            this.btn_alugar.UseVisualStyleBackColor = true;
            this.btn_alugar.Click += new System.EventHandler(this.Btn_alugar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.mtb_dtentrega);
            this.groupBox3.Controls.Add(this.mtb_dtretirada);
            this.groupBox3.Controls.Add(this.mtb_preco);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.groupBox3.Location = new System.Drawing.Point(263, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 203);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acordos Locação:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 11);
            this.label4.TabIndex = 23;
            this.label4.Text = "DD/MM/AAAA";
            // 
            // mtb_dtentrega
            // 
            this.mtb_dtentrega.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.mtb_dtentrega.Location = new System.Drawing.Point(124, 110);
            this.mtb_dtentrega.Mask = "00/00/0000";
            this.mtb_dtentrega.Name = "mtb_dtentrega";
            this.mtb_dtentrega.Size = new System.Drawing.Size(100, 23);
            this.mtb_dtentrega.TabIndex = 22;
            this.mtb_dtentrega.ValidatingType = typeof(System.DateTime);
            this.mtb_dtentrega.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.Mtb_dtentrega_MaskInputRejected);
            // 
            // mtb_dtretirada
            // 
            this.mtb_dtretirada.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.mtb_dtretirada.Location = new System.Drawing.Point(8, 111);
            this.mtb_dtretirada.Mask = "00/00/0000";
            this.mtb_dtretirada.Name = "mtb_dtretirada";
            this.mtb_dtretirada.Size = new System.Drawing.Size(100, 23);
            this.mtb_dtretirada.TabIndex = 21;
            // 
            // mtb_preco
            // 
            this.mtb_preco.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.mtb_preco.Location = new System.Drawing.Point(8, 66);
            this.mtb_preco.Mask = " 999999.00";
            this.mtb_preco.Name = "mtb_preco";
            this.mtb_preco.Size = new System.Drawing.Size(100, 23);
            this.mtb_preco.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(118, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Data Entrega:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Data Retirada:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Preço da Diaria:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_placa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_cpf);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.groupBox1.Location = new System.Drawing.Point(9, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 203);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Locação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Placa:";
            // 
            // txt_placa
            // 
            this.txt_placa.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_placa.Location = new System.Drawing.Point(16, 153);
            this.txt_placa.Name = "txt_placa";
            this.txt_placa.Size = new System.Drawing.Size(207, 23);
            this.txt_placa.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "CPF:";
            // 
            // txt_cpf
            // 
            this.txt_cpf.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cpf.Location = new System.Drawing.Point(16, 106);
            this.txt_cpf.Name = "txt_cpf";
            this.txt_cpf.Size = new System.Drawing.Size(207, 23);
            this.txt_cpf.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "ID Locação:";
            // 
            // txt_id
            // 
            this.txt_id.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.Location = new System.Drawing.Point(16, 60);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(207, 23);
            this.txt_id.TabIndex = 0;
            // 
            // lbl_devolver
            // 
            this.lbl_devolver.AutoSize = true;
            this.lbl_devolver.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_devolver.Location = new System.Drawing.Point(140, 318);
            this.lbl_devolver.Name = "lbl_devolver";
            this.lbl_devolver.Size = new System.Drawing.Size(91, 16);
            this.lbl_devolver.TabIndex = 24;
            this.lbl_devolver.Text = "Preço da Taxa:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(155, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "0.8%/Dia";
            // 
            // Frm_Locacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 360);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_devolver);
            this.Controls.Add(this.btn_listar);
            this.Controls.Add(this.btn_alterar);
            this.Controls.Add(this.btn_devolver);
            this.Controls.Add(this.btn_alugar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Locacoes";
            this.Text = "Locacoes";
            this.Load += new System.EventHandler(this.Frm_Locacoes_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_listar;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_placa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_cpf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.MaskedTextBox mtb_dtentrega;
        private System.Windows.Forms.MaskedTextBox mtb_dtretirada;
        private System.Windows.Forms.MaskedTextBox mtb_preco;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btn_devolver;
        public System.Windows.Forms.Button btn_alugar;
        public System.Windows.Forms.Label lbl_devolver;
        public System.Windows.Forms.Label label7;
    }
}