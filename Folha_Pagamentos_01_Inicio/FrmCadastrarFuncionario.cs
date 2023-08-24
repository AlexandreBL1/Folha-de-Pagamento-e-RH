using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace Folha_Pagamentos_01_Inicio
{
    public partial class FrmCadastrarFuncionario : Form
    {

        int ultimo_Id;
        int novo_Id;
        public FrmCadastrarFuncionario()
        {
            int ultimo_Id;
            int novo_Id;
             string matricula_num;
            InitializeComponent();
            using (NpgsqlConnection con = BD.GetConnection())
            {
                con.Open();
                string query = "Select max(id_func) from funcionario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    ultimo_Id = Convert.ToInt32(cmd.ExecuteScalar());
                    novo_Id = ultimo_Id + 1;
                    textbox_matricula.Text = novo_Id.ToString();
                }
                con.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Datenasci_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
              {
                decimal sal_base;
                sal_base = Math.Round(Convert.ToDecimal(textbox_salariobase.Text), 2);

                BD.InsertCadastro(textbox_Nome.Text,
                                     textbox_CPF.Text,
                                     textbox_Email.Text,
                                     textbox_senha.Text,
                                     textbox_telefone.Text,
                                     dateTimePicker3.Value, // data de nascimento
                                     dateTimePicker1.Value, //data de admissao
                                     comboBox1.Text, //departamento
                                     comboBox2.Text, //cargo
                                     comboBox3.Text,  //status
                                     sal_base);
                MessageBox.Show("Funcionario Cadastrado com Sucesso!");
                this.Close();
             } catch(Exception ex) { MessageBox.Show("Há campo(s) em branco para ser preenchido(s)"); }
            
            BD.InsertEndereço(textbox_Nome.Text, textbox_CPF.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textbox_CEP_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmCadastrarFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

         void textbox_matricula_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCadastrarEndereco folhafuncionarios = new FrmCadastrarEndereco();
            folhafuncionarios.ShowDialog();
        }

        private void textbox_Nome_TextChanged(object sender, EventArgs e)
        {
            
               
            

        }

        private void dateTimePicker3_Validating(object sender, CancelEventArgs e)
        {
            DateTime data_nascimento = dateTimePicker3.Value.Date;
            DateTime data_admissao = dateTimePicker1.Value.Date;

            if (data_nascimento > DateTime.Now.Date)
            {
                MessageBox.Show("Data inválida. Selecione uma data anterior à data atual.");
                e.Cancel = true;
            }

            if (data_nascimento >= data_admissao)
            {
                MessageBox.Show("Data inválida. Selecione uma data anterior à data admissão.");
                e.Cancel = true;
            }

        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            DateTime data_nascimento = dateTimePicker3.Value.Date;
            DateTime data_admissao = dateTimePicker1.Value.Date;

            if (data_admissao > DateTime.Now.Date)
            {
                MessageBox.Show("Data inválida. Selecione uma data anterior ou igual à data atual.");
                e.Cancel = true;
            }

            if (data_admissao <= data_nascimento)
            {
                MessageBox.Show("Data inválida. Selecione uma data posterior à data de nascimento.");
                e.Cancel = true;
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!comboBox1.Items.Contains(comboBox1.Text))
            {
                MessageBox.Show("Selecione uma opção válida.");
                comboBox1.Focus();
                e.Cancel = true;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!comboBox2.Items.Contains(comboBox2.Text))
            {
                MessageBox.Show("Selecione uma opção válida.");
                comboBox1.Focus();
                e.Cancel = true;
            }
        }

        private void comboBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!comboBox3.Items.Contains(comboBox3.Text))
            {
                MessageBox.Show("Selecione uma opção válida.");
                comboBox1.Focus();
                e.Cancel = true;
            }
        }

        private void textbox_salariobase_Validating(object sender, CancelEventArgs e)
        {
            int valor;
            if (!int.TryParse(textbox_salariobase.Text, out valor) || valor <= 0)
            {
                MessageBox.Show("Digite um valor válido.");
                textbox_salariobase.Focus();
                e.Cancel = true;
            }

        }

        private void textbox_Nome_Validating(object sender, CancelEventArgs e)
        {
            string nomeCompleto = textbox_Nome.Text.Trim();

            // Verifica se o campo está vazio
            if (string.IsNullOrWhiteSpace(nomeCompleto))
            {
                // Campo vazio, não precisa realizar a validação
                return;
            }



            // Expressão regular para validar o nome e sobrenome
            string regexPattern = @"^[A-Z]+(\s+[A-Z]+)+$";
                                  

            if (Regex.IsMatch(nomeCompleto, regexPattern))
            {
                // Nome e sobrenome são válidos
                // Adicione aqui o código adicional que deseja executar quando o nome é válido
                // ...
            }
            else
            {
                // Nome e sobrenome são inválidos
                MessageBox.Show("O nome deve conter pelo menos um nome e um sobrenome!");
                e.Cancel = true;
            }
        }

    }
}
