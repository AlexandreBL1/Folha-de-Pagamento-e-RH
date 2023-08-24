using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Windows.Forms;

namespace Folha_Pagamentos_01_Inicio
{
    public partial class FrmConsultarFuncionario : Form
    {
        public static string func_nome;
        public FrmConsultarFuncionario()
        {
            InitializeComponent();
            txtPesquisa.Text = "";
            func_nome = txtPesquisa.Text;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            List<Funcionario> funcionarios = BD.Listar(func_nome);

            dataGridView1.Columns.Add("Matricula", "Matricula");
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Telefone", "Telefone");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("cpf", "CPF");
            dataGridView1.Columns.Add("dt_nasc", "Data Nascimento");
            dataGridView1.Columns.Add("dt_adm", "Admissão");
            dataGridView1.Columns.Add("salario_base", "Salario Bruto");
            dataGridView1.Columns.Add("cargo", "Cargo");
            dataGridView1.Columns.Add("depto", "Departamento");
            dataGridView1.Columns.Add("status", "Status");


            foreach (var funcionario in funcionarios)
            {
                dataGridView1.Rows.Add(funcionario.Matricula, funcionario.Nome, funcionario.Telefone, funcionario.Email, funcionario.cpf, funcionario.dt_nasc, funcionario.dt_adm, funcionario.salario_base, funcionario.depto, funcionario.cargo, funcionario.status);
            }

            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "dt_nasc" || dataGridView1.Columns[e.ColumnIndex].Name == "dt_adm")

            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    string valueStr = e.Value.ToString();
                    DateTime dtNasc;
                    if (DateTime.TryParse(valueStr, out dtNasc))
                    {
                        e.Value = dtNasc.ToString("dd/MM/yyyy");
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnLocalizarFunci_Click(object sender, EventArgs e)
        {
            if (cbInativos.Checked)
            {
                func_nome = txtPesquisa.Text;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<Funcionario> func = BD.ListarInativos(func_nome);

                dataGridView1.Columns.Add("Matricula", "Matricula");
                dataGridView1.Columns.Add("Nome", "Nome");
                dataGridView1.Columns.Add("Telefone", "Telefone");
                dataGridView1.Columns.Add("Email", "Email");
                dataGridView1.Columns.Add("cpf", "CPF");
                dataGridView1.Columns.Add("dt_nasc", "Data Nascimento");
                dataGridView1.Columns.Add("dt_adm", "Admissão");
                dataGridView1.Columns.Add("salario_base", "Salario Bruto");
                dataGridView1.Columns.Add("cargo", "Cargo");
                dataGridView1.Columns.Add("depto", "Departamento");
                dataGridView1.Columns.Add("status", "Status");


                foreach (var funcionario in func)
                {
                    dataGridView1.Rows.Add(funcionario.Matricula, funcionario.Nome, funcionario.Telefone, funcionario.Email, funcionario.cpf, funcionario.dt_nasc, funcionario.dt_adm, funcionario.salario_base, funcionario.depto, funcionario.cargo, funcionario.status);
                }

                dataGridView1.CellFormatting += dataGridView1_CellFormatting;

                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
            }
            else
            {
                func_nome = txtPesquisa.Text;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                List<Funcionario> funcionarios = BD.Listar(func_nome);

                dataGridView1.Columns.Add("Matricula", "Matricula");
                dataGridView1.Columns.Add("Nome", "Nome");
                dataGridView1.Columns.Add("Telefone", "Telefone");
                dataGridView1.Columns.Add("Email", "Email");
                dataGridView1.Columns.Add("cpf", "CPF");
                dataGridView1.Columns.Add("dt_nasc", "Data Nascimento");
                dataGridView1.Columns.Add("dt_adm", "Admissão");
                dataGridView1.Columns.Add("salario_base", "Salario Bruto");
                dataGridView1.Columns.Add("cargo", "Cargo");
                dataGridView1.Columns.Add("depto", "Departamento");
                dataGridView1.Columns.Add("status", "Status");


                foreach (var funcionario in funcionarios)
                {
                    dataGridView1.Rows.Add(funcionario.Matricula, funcionario.Nome, funcionario.Telefone, funcionario.Email, funcionario.cpf, funcionario.dt_nasc, funcionario.dt_adm, funcionario.salario_base, funcionario.depto, funcionario.cargo, funcionario.status);
                }

                dataGridView1.CellFormatting += dataGridView1_CellFormatting;

                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtenha a linha selecionada
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // Crie uma nova instância do formulário que deseja abrir
                FrmEditarFunc form2 = new FrmEditarFunc();

                // Preencha os valores das caixas de texto no novo formulário com os valores da linha selecionada
                form2.textoMatricula = row.Cells[0].Value.ToString();
                //form2.textBox2.Text = row.Cells[1].Value.ToString();
                //form2.textBox3.Text = row.Cells[2].Value.ToString();

                // Abra o novo formulário
                form2.Show();
            }



        }

        private void FrmConsultarFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        // Obtenha a linha selecionada
                        DataGridViewRow row = dataGridView1.SelectedRows[0];

                        // Crie uma nova instância do formulário que deseja abrir
                        FrmEditarFunc form2 = new FrmEditarFunc();

                        // Preencha os valores das caixas de texto no novo formulário com os valores da linha selecionada
                        form2.textoMatricula = row.Cells[0].Value.ToString();
                        //form2.textBox2.Text = row.Cells[1].Value.ToString();
                        //form2.textBox3.Text = row.Cells[2].Value.ToString();

                        // Abra o novo formulário
                        form2.Show();
                    }
                    break;

            }
        }
    }
}
