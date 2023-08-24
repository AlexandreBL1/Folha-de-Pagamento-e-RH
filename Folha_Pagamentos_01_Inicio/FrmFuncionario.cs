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
    public partial class FrmFuncionario : Form
    {
        public FrmFuncionario()
        {
            InitializeComponent();
        }

        private void btnConsultarfuncionario_Click(object sender, EventArgs e)
        {
            FrmConsultarFuncionario folhafuncionarios = new FrmConsultarFuncionario();
            folhafuncionarios.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelFunci_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            FrmCadastrarFuncionario folhafuncionarios = new FrmCadastrarFuncionario();
            folhafuncionarios.ShowDialog();
        }

        private void btnEditarfuncionario_Click(object sender, EventArgs e)
        {
            FrmEditarFunc folhafuncionarios = new FrmEditarFunc();
            folhafuncionarios.ShowDialog();
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {

        }
    }
}
