using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Folha_Pagamentos_01_Inicio
{
    public partial class FrmConsultarFolha : Form
    {
        public FrmConsultarFolha()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("competencia", "Competencia");
            dataGridView1.Columns.Add("Matricula", "Matricula");
            dataGridView1.Columns.Add("Nome", "Nome");
            //dataGridView1.Columns.Add("salario_base", "Salario Base");
            dataGridView1.Columns.Add("taxa_hora", "Taxa Hora");
            dataGridView1.Columns.Add("horas_trabalhadas", "Horas Trabalhadas");
            dataGridView1.Columns.Add("horas_normais", "Horas Normais");
            dataGridView1.Columns.Add("horas_extras", "Horas Extras");
            //dataGridView1.Columns.Add("salario_liquidos", "Salario Liquido");
            dataGridView1.Columns.Add("desconto_inss", "Descontos INSS");
            dataGridView1.Columns.Add("desconto_irrf", "Desconto IRRF");
            dataGridView1.Columns.Add("salario_liquido", "Salario Liquido");

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmConsultarFolha_Load(object sender, EventArgs e)
        {
            string query = "SELECT DISTINCT competencia FROM PONTO";
            using (NpgsqlConnection conn = BD.GetConnection())
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string competencia = reader["competencia"].ToString();
                            comboBox1.Items.Add(competencia);
                        }
                    }
                }
            }
        }

        private void btnLocalizarFunci_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string comp = comboBox1.Text;
            int matricula = Convert.ToInt32(txtMatricula.Text);
            List<Salario> func = BD.FolhaPag(comp, matricula);
            foreach (var funcionario in func)
            {
                dataGridView1.Rows.Add(funcionario.competencia, funcionario.Matricula, funcionario.Nome, /*funcionario.Salario_Bruto,*/ funcionario.taxa_hora, funcionario.horas_trabalhadas, funcionario.horas_normais, funcionario.horas_extra, funcionario.inss_desc, funcionario.irrf_desc, funcionario.sal_liquido);

            }
        }




















    }
}
