using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Folha_Pagamentos_01_Inicio
{
    public partial class form_principal : Form
    {

        private Form frmAtivo;



        public form_principal()
        {
            InitializeComponent();
        }

        private void FormShow(Form frm)
        {
            ActiveFormClose();
            frmAtivo = frm;
            frm.TopLevel = false;
            panelForm.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void ActiveFormClose()
        {
            if (frmAtivo != null)
                frmAtivo.Close();
        }

        private void ActiveButton(Button frmAtivo)
        {
            foreach (Control crtl in panelPrincipal.Controls)
                crtl.ForeColor = Color.Black;

            frmAtivo.ForeColor = Color.DarkBlue;

        }



        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            ActiveButton(btnHome);
            ActiveFormClose();
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            ActiveButton(btnFuncionario);
            FormShow(new FrmFuncionario());
        }

        private void btnHolerite_Click(object sender, EventArgs e)
        {
            ActiveButton(btnHolerite);
            FormShow(new FrmHolerite());
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            ActiveButton(btnPonto);
            FormShow(new FrmPonto());
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            ActiveButton(btnFechar);
            ActiveFormClose();
            Application.Exit();
        }

        private void testeToolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }
    }
}
