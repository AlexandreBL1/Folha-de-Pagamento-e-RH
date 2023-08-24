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
    public partial class FrmMenuFuncionario : Form
    {

        private Form frmAtivo;

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

        public FrmMenuFuncionario()
        {
            InitializeComponent();
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            ActiveButton(btnFuncionario);
            FormShow(new FrmDadosFuncionario());
        }

        private void btnHolerite_Click(object sender, EventArgs e)
        {
            FrmHoleriteFunc hol = new FrmHoleriteFunc();
            hol.Show();
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            ActiveButton(btnPonto);
            FormShow(new FrmBaterPontoFuncionario());
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            ActiveButton(btnFechar);
            ActiveFormClose();
            Application.Exit();
        }
    }
}
