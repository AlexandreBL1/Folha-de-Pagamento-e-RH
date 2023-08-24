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
    public partial class FrmPonto : Form
    {
        public FrmPonto()
        {
            InitializeComponent();
        }

        private void btnFolhadeponto_Click(object sender, EventArgs e)
        {
            /*FrmFolhadePonto folhafuncionarios = new FrmFolhadePonto();
            folhafuncionarios.ShowDialog();*/
            FrmApontamento frmApontamento = new FrmApontamento();
            frmApontamento.ShowDialog();
        }
    }
}
