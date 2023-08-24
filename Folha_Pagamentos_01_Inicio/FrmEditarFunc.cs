using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Folha_Pagamentos_01_Inicio
{
    public partial class FrmEditarFunc : Form
    {
        string nome_f, cpf_f, email_f, status_f, cargo_f, depto_f, telefone_f, senha_f;
        decimal sal_f;
        int id_f;

        public string textoMatricula
        {
            get { return textbox_matriculaEdit.Text; }
            set { textbox_matriculaEdit.Text = value; }
        }

        private void FrmEditarFunc_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEditarEndereco folhafuncionarios = new FrmEditarEndereco();
            folhafuncionarios.ShowDialog();
        }

        DateTime dt_nasc_f, dt_adm_f;
        public FrmEditarFunc()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textbox_matriculaEdit.Text);
            string nome = textbox_Nome.Text;
            string cpf = textbox_CPF.Text;
            string email = textbox_Email.Text;
            string telefone = textbox_telefone.Text;
            DateTime dt_nasc = date.Value;
            DateTime dt_adm = dateTimePicker1.Value;
            decimal salario = Convert.ToDecimal(textbox_salario.Text);
            string depto = textbox_depto.Text;
            string cargo = textbox_cargo.Text;
            string status = textbox_status.Text;

            using (NpgsqlConnection con = BD.GetConnection())
            {
                con.Open();
                string query = "UPDATE funcionario SET nome_func = @nome, cpf = @cpf, email = @email, telefone = @telefone, dt_nasc = @dtnasc, dt_adm = @dtadm, salario_base = @salario, depto = @depto, cargo = @cargo, status = @status WHERE id_func = @id ";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@dtnasc", dt_nasc);
                    cmd.Parameters.AddWithValue("@dtadm", dt_adm);
                    cmd.Parameters.AddWithValue("@salario", salario);
                    cmd.Parameters.AddWithValue("@depto", depto);
                    cmd.Parameters.AddWithValue("@cargo", cargo);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Funcionario Editado com Sucesso!");
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            // Criando uma cultura personalizada com separador de milhar como ponto e separador decimal como vírgula
            CultureInfo culturaPersonalizada = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            culturaPersonalizada.NumberFormat.NumberGroupSeparator = ".";
            culturaPersonalizada.NumberFormat.NumberDecimalSeparator = ",";


            int nome_matricula = Convert.ToInt32(textbox_matriculaEdit.Text);
            using (NpgsqlConnection con = BD.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM funcionario WHERE id_func = @matricula";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@matricula", nome_matricula);
                    using (NpgsqlDataReader dt = cmd.ExecuteReader())
                    {
                        if (dt.HasRows)
                        {
                            while (dt.Read())
                            {
                                id_f = dt.GetInt32(0);
                                nome_f = dt.GetString(1);
                                cpf_f = dt.GetString(2);
                                email_f = dt.GetString(3);
                                senha_f = dt.GetString(4);
                                telefone_f = dt.GetString(5);
                                dt_nasc_f = dt.GetDateTime(6);
                                dt_adm_f = dt.GetDateTime(7);
                                sal_f = Convert.ToDecimal(dt.GetDouble(8));
                                depto_f = dt.GetString(9);
                                cargo_f = dt.GetString(10);
                                status_f = dt.GetString(11);

                                textbox_Nome.Text = nome_f;
                                textbox_CPF.Text = cpf_f;
                                textbox_Email.Text = email_f;
                                textbox_senha.Text = senha_f;
                                textbox_telefone.Text = telefone_f;
                                date.Value = dt_nasc_f;
                                dateTimePicker1.Value = dt_adm_f;
                                textbox_depto.Text = depto_f;
                                textbox_status.Text = status_f;
                                textbox_cargo.Text = cargo_f;
                                textbox_salario.Text = sal_f.ToString("N2", culturaPersonalizada);

                                textbox_matriculaEdit.ReadOnly = true;

                            }
                        }
                    }
                }

            }
        }
    }
}
