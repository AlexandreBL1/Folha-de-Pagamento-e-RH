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
    public partial class FrmHolerite : Form
    {
        public FrmHolerite()
        {
            InitializeComponent();
        }

        private void btnConsultarHolerite_Click(object sender, EventArgs e)
        {
            FrmConsultarHolerite folhafuncionarios = new FrmConsultarHolerite();
            folhafuncionarios.ShowDialog();
        }

        private void FrmHolerite_Load(object sender, EventArgs e)
        {

        }
    }
}
