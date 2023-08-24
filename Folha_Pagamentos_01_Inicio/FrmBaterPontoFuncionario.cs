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
    public partial class FrmBaterPontoFuncionario : Form
    {
        static TimeSpan HoraAtual = DateTime.Now.TimeOfDay;
        string horaFormatada = DateTime.Now.ToString(@"hh\:mm\:ss");
        DateTime hora = DateTime.Now;
        public FrmBaterPontoFuncionario()
        {
            InitializeComponent();
        }

        private void FrmBaterPontoFuncionario_Load(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.text_relogio.Text = DateTime.Now.ToString("HH:mm:ss");
            DateTime hora = DateTime.Now;
        }

        private void text_relogio_Click(object sender, EventArgs e)
        {

        }

        private void btnBaterPonto_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ENTRADA")
            { 
                MessageBox.Show("Ponto de entrada do funcionario "+FuncionarioLogado.funcionario_cpf+ " registrado as " + DateTime.Now.ToString(@"HH\:mm\:ss") + " com sucesso!");
            } else if (comboBox1.Text == "SAÍDA")
            {

                MessageBox.Show("Ponto de Saída do funcionario " + FuncionarioLogado.funcionario_cpf +" registrado as " + DateTime.Now.ToString(@"HH\:mm\:ss") + " com sucesso!");
            }else
            {
                MessageBox.Show("Por favor selecione uma opção de ponto");
            }
        }
    }
}
