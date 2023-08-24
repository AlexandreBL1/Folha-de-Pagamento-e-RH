namespace Folha_Pagamentos_01_Inicio
{
    partial class FrmFolha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFolha));
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditarfuncionario = new System.Windows.Forms.Button();
            this.btnConsultarfuncionario = new System.Windows.Forms.Button();
            this.panelFunci = new System.Windows.Forms.Panel();
            this.panelFunci.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(184, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 104);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folha";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnEditarfuncionario
            // 
            this.btnEditarfuncionario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditarfuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarfuncionario.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnEditarfuncionario.FlatAppearance.BorderSize = 0;
            this.btnEditarfuncionario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.btnEditarfuncionario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditarfuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarfuncionario.Font = new System.Drawing.Font("Bahnschrift SemiLight", 20F);
            this.btnEditarfuncionario.ForeColor = System.Drawing.Color.Black;
            this.btnEditarfuncionario.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarfuncionario.Image")));
            this.btnEditarfuncionario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarfuncionario.Location = new System.Drawing.Point(131, 226);
            this.btnEditarfuncionario.Name = "btnEditarfuncionario";
            this.btnEditarfuncionario.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEditarfuncionario.Size = new System.Drawing.Size(353, 97);
            this.btnEditarfuncionario.TabIndex = 2;
            this.btnEditarfuncionario.Text = "Processar Folha Empresa";
            this.btnEditarfuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarfuncionario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditarfuncionario.UseVisualStyleBackColor = false;
            this.btnEditarfuncionario.Click += new System.EventHandler(this.btnEditarfuncionario_Click);
            // 
            // btnConsultarfuncionario
            // 
            this.btnConsultarfuncionario.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultarfuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultarfuncionario.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnConsultarfuncionario.FlatAppearance.BorderSize = 0;
            this.btnConsultarfuncionario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.btnConsultarfuncionario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnConsultarfuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarfuncionario.Font = new System.Drawing.Font("Bahnschrift SemiLight", 20F);
            this.btnConsultarfuncionario.ForeColor = System.Drawing.Color.Black;
            this.btnConsultarfuncionario.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarfuncionario.Image")));
            this.btnConsultarfuncionario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarfuncionario.Location = new System.Drawing.Point(211, 231);
            this.btnConsultarfuncionario.Name = "btnConsultarfuncionario";
            this.btnConsultarfuncionario.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnConsultarfuncionario.Size = new System.Drawing.Size(353, 97);
            this.btnConsultarfuncionario.TabIndex = 1;
            this.btnConsultarfuncionario.Text = "Consultar Folha";
            this.btnConsultarfuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarfuncionario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultarfuncionario.UseVisualStyleBackColor = false;
            this.btnConsultarfuncionario.Click += new System.EventHandler(this.btnConsultarfuncionario_Click);
            // 
            // panelFunci
            // 
            this.panelFunci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.panelFunci.Controls.Add(this.btnEditarfuncionario);
            this.panelFunci.Controls.Add(this.label1);
            this.panelFunci.Location = new System.Drawing.Point(80, 121);
            this.panelFunci.Name = "panelFunci";
            this.panelFunci.Size = new System.Drawing.Size(613, 351);
            this.panelFunci.TabIndex = 10;
            // 
            // FrmFolha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 618);
            this.Controls.Add(this.btnConsultarfuncionario);
            this.Controls.Add(this.panelFunci);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFolha";
            this.Text = "FrmFolha";
            this.panelFunci.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditarfuncionario;
        private System.Windows.Forms.Button btnConsultarfuncionario;
        private System.Windows.Forms.Panel panelFunci;
    }
}