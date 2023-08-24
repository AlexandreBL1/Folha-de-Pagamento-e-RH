namespace Folha_Pagamentos_01_Inicio
{
    partial class FrmPonto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPonto));
            this.label1 = new System.Windows.Forms.Label();
            this.btnFolhadeponto = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
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
            this.label1.Text = "Ponto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFolhadeponto
            // 
            this.btnFolhadeponto.BackColor = System.Drawing.Color.Transparent;
            this.btnFolhadeponto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolhadeponto.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnFolhadeponto.FlatAppearance.BorderSize = 0;
            this.btnFolhadeponto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.btnFolhadeponto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFolhadeponto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolhadeponto.Font = new System.Drawing.Font("Bahnschrift SemiLight", 20F);
            this.btnFolhadeponto.ForeColor = System.Drawing.Color.Black;
            this.btnFolhadeponto.Image = ((System.Drawing.Image)(resources.GetObject("btnFolhadeponto.Image")));
            this.btnFolhadeponto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFolhadeponto.Location = new System.Drawing.Point(211, 181);
            this.btnFolhadeponto.Name = "btnFolhadeponto";
            this.btnFolhadeponto.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFolhadeponto.Size = new System.Drawing.Size(353, 97);
            this.btnFolhadeponto.TabIndex = 7;
            this.btnFolhadeponto.Text = "Folha de Ponto";
            this.btnFolhadeponto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFolhadeponto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFolhadeponto.UseVisualStyleBackColor = false;
            this.btnFolhadeponto.Click += new System.EventHandler(this.btnFolhadeponto_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(80, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 471);
            this.panel1.TabIndex = 10;
            // 
            // FrmPonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 618);
            this.Controls.Add(this.btnFolhadeponto);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPonto";
            this.Text = "FrmPonto";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFolhadeponto;
        private System.Windows.Forms.Panel panel1;
    }
}