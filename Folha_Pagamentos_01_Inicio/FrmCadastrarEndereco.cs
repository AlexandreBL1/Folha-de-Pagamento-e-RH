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
    public partial class FrmCadastrarEndereco : Form
    {
        public FrmCadastrarEndereco()
        {
            InitializeComponent();
        }
        public static string Endereço;
        public static string Cep;
        public static string N;
        public static string Complemento;
        public static string Cidade;
        public static string Estado;
        private void btnGravar_Click(object sender, EventArgs e)
        {
            salvarEndereço(textbox_Endereco.Text, textbox_CEP.Text, textbox_Numero.Text, textbox_Complemento.Text, textbox_Cidade.Text, textbox_Estado.Text);
            MessageBox.Show("Endereço salvo!");
            this.Close();

        }
        public void salvarEndereço(string endereço, string cep, string n, string complemento, string cidade, string estado)
        {
           Endereço = endereço;
           Cep = cep;
           N = n;
           Complemento = complemento;
           Cidade = cidade;
           Estado = estado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadastrarEndereco_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textbox_Endereco_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
