using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Folha_Pagamentos_01_Inicio
{
    public partial class FrmDadosFuncionario : Form
    {
        public FrmDadosFuncionario()
        {
            Salario sal = new Salario();

            int matricula_func, id_end, id_func2;
            string nome, cpf, email, senha, tel, depto, cargo, status, rua, numero, cidade, estado, complemento, cep;
            decimal salario_funuc;
            DateTime dt_nasc, dt_adm;

            InitializeComponent();

            Form_Login log = new Form_Login();
            string login_func = FuncionarioLogado.funcionario_cpf;
            using (NpgsqlConnection con = BD.GetConnection())
            {
                string query = "select f.*, e.* from funcionario f join endereco e on f.id_func = e.id_func where f.cpf = @cpf";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@cpf", login_func);
                    con.Open();

                    using (NpgsqlDataReader dt = cmd.ExecuteReader())
                    {
                        if (dt.HasRows)
                        {
                            while (dt.Read())
                            {
                                matricula_func = dt.GetInt32(0);
                                nome = dt.GetString(1);
                                cpf = dt.GetString(2);
                                email = dt.GetString(3);
                                senha = dt.GetString(4);
                                tel = dt.GetString(5);
                                dt_nasc = dt.GetDateTime(6);
                                dt_adm = dt.GetDateTime(7);
                                salario_funuc = Convert.ToDecimal(dt.GetDouble(8));
                                depto = dt.GetString(9);
                                cargo = dt.GetString(10);
                                status = dt.GetString(11);
                                id_end = dt.GetInt32(12);
                                id_func2 = dt.GetInt32(13);
                                rua = dt.GetString(14);
                                numero = dt.GetString(15);
                                complemento = dt.GetString(16);
                                cidade = dt.GetString(17);
                                estado = dt.GetString(18);
                                cep = dt.GetString(19);


                                textbox_matricula.Text = matricula_func.ToString();
                                textbox_Nome.Text = nome;
                                textbox_CPF.Text = cpf.ToString();
                                textbox_Email.Text = email.ToString();
                                textbox_telefone.Text = tel.ToString();
                                textbox_senha.Text = senha.ToString();
                                date.Value = dt_nasc;
                                dateTimePicker1.Value = dt_adm;
                                text_depto.Text = depto.ToString();
                                text_cargo.Text = cargo.ToString();
                                text_status.Text = status.ToString();
                                textbox_salariobase.Text = (salario_funuc).ToString("N2", CultureInfo.InvariantCulture);
                                textbox_Endereco.Text = rua.ToString();
                                textbox_CEP.Text = cep.ToString();
                                textbox_Numero.Text = numero.ToString();
                                textbox_Complemento.Text = complemento.ToString();
                                textbox_Cidade.Text = cidade.ToString();
                                textbox_Estado.Text = estado.ToString();




                            }

                        }
                    }
                }
            }

        }

        private void textbox_telefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void FrmDadosFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void btnSenha_Click(object sender, EventArgs e)
        {
            if (textbox_senha.PasswordChar == '*')
            {
                textbox_senha.PasswordChar = '\0';
                btnSenha.Image = Properties.Resources.icons8_visível_25;

            }
            else
            {
                textbox_senha.PasswordChar = '*';
                btnSenha.Image = Properties.Resources.icons8_ocultar_25;

            }
        }

        private void btnSenha_Click_1(object sender, EventArgs e)
        {
            if (textbox_senha.PasswordChar == '*')
            {
                textbox_senha.PasswordChar = '\0';
                btnSenha.Image = Properties.Resources.icons8_visível_25;

            }
            else
            {
                textbox_senha.PasswordChar = '*';
                btnSenha.Image = Properties.Resources.icons8_ocultar_25;

            }
        }
    }
}