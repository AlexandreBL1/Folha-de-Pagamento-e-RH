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

namespace Folha_Pagamentos_01_Inicio
{
    public partial class FrmProcessarFolha : Form
    {
        public FrmProcessarFolha()
        {
            double inss1 = 1693.72;
            double inss2 = 2822.90;
            double inss3 = 5645.80;


            InitializeComponent();
            //List<Salario> func = BD.HorasFunc();

            dataGridView1.Columns.Add("competencia", "Competencia");
            dataGridView1.Columns.Add("Matricula", "Matricula");
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("salario_base", "Salario Base");
            dataGridView1.Columns.Add("taxa_hora", "Taxa Hora");
            dataGridView1.Columns.Add("horas_trabalhadas", "Horas Trabalhadas");
            dataGridView1.Columns.Add("horas_normais", "Horas Normais");
            dataGridView1.Columns.Add("horas_extras", "Horas Extras");
            //dataGridView1.Columns.Add("salario_liquidos", "Salario Liquido");
            dataGridView1.Columns.Add("desconto_inss", "Descontos INSS");
            dataGridView1.Columns.Add("desconto_irrf", "Desconto IRRF");
            dataGridView1.Columns.Add("salario_liquido", "Salario Liquido");


            //foreach (var funcionario in func)
            //{
            //    dataGridView1.Rows.Add(funcionario.competencia, funcionario.Matricula, funcionario.Nome, funcionario.Salario_Bruto, funcionario.taxa_hora, funcionario.horas_trabalhadas, funcionario.horas_normais, funcionario.horas_extra);

            //}

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }

        private void FrmProcessarFolha_Load(object sender, EventArgs e)
        {
            // Preencher o ComboBox com as opções de competência
            string connString = "Server=localhost;Port=5432;User Id=postgres;Password=dbadmin;Database=local";
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
        private void btnProcessar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string comp = comboBox1.Text;
            try
            {
                List<Salario> func = BD.HorasFunc(comp);
                foreach (var funcionario in func)
                {
                    dataGridView1.Rows.Add(funcionario.competencia, funcionario.Matricula, funcionario.Nome, funcionario.Salario_Bruto, funcionario.taxa_hora, funcionario.horas_trabalhadas, funcionario.horas_normais, funcionario.horas_extra);

                }
                foreach (DataGridViewRow linha in dataGridView1.Rows)
                {
                    string competencia = linha.Cells["competencia"].ToString();
                    int matricula = Convert.ToInt32(linha.Cells["Matricula"].Value);
                    string nome = linha.Cells["Nome"].Value.ToString();
                    double salarioBase = Convert.ToDouble(linha.Cells["salario_base"].Value);
                    decimal taxaHora = Convert.ToDecimal(linha.Cells["taxa_hora"].Value);
                    decimal horasTrabalhadas = Convert.ToDecimal(linha.Cells["horas_trabalhadas"].Value);
                    decimal horasNormais = Convert.ToDecimal(linha.Cells["horas_normais"].Value);
                    decimal horasExtra = Convert.ToDecimal(linha.Cells["horas_extras"].Value);
                    double inss1 = 1693.73;
                    double inss2 = 2822.91;
                    decimal salario_2 = 0;
                    decimal salario_pos_inss;
                    double salario_pos_irrf;
                    decimal salario_liquido = 1;
                    string salario_2Formato = salario_liquido.ToString("N2");

                    decimal adicional = horasNormais - horasExtra;
                    decimal salario_1 = (horasNormais * taxaHora) + (horasExtra * (taxaHora * 1.5m));
                    double salario_1Double = Convert.ToDouble(salario_1);

                    if (salario_1Double < inss1)
                    {
                        salario_pos_inss = ((salario_1 / 100) * 8);
                        salario_2 = salario_1 - salario_pos_inss;
                        //linha.Cells["salario_liquidos"].Value = salario_2.ToString("N2");
                        linha.Cells["desconto_inss"].Value = salario_pos_inss.ToString("N2");
                    }
                    else if (salario_1Double < inss2)
                    {
                        salario_pos_inss = ((salario_1 / 100) * 9);
                        salario_2 = salario_1 - salario_pos_inss;
                        //linha.Cells["salario_liquidos"].Value = salario_2.ToString("N2");
                        linha.Cells["desconto_inss"].Value = salario_pos_inss.ToString("N2");

                    }
                    else if (salario_1Double > inss2)
                    {

                        salario_pos_inss = ((salario_1 / 100) * 11);
                        salario_2 = salario_1 - salario_pos_inss;
                        //linha.Cells["salario_liquidos"].Value = salario_2.ToString("N2");
                        linha.Cells["desconto_inss"].Value = salario_pos_inss.ToString("N2");
                    }

                    string salario_1Formato = salario_1.ToString("N2");
                    double salario_2double = Convert.ToDouble(salario_2);
                    double irrf1 = 1903.99;
                    double irrf2 = 2826.66;
                    double irrf3 = 3751.06;
                    double irrf4 = 4664.69;
                    if (salario_2double < irrf1)
                    {
                        salario_liquido = salario_2;
                        linha.Cells["salario_liquido"].Value = salario_liquido.ToString("N2");
                        linha.Cells["desconto_irrf"].Value = 0;
                    }
                    else if (salario_2double < irrf2)
                    {
                        salario_pos_irrf = ((salario_2double / 100) * 7.5) - 142.80;
                        salario_liquido = Convert.ToDecimal(salario_2double - salario_pos_irrf);
                        linha.Cells["salario_liquido"].Value = salario_liquido.ToString("N2");
                        linha.Cells["desconto_irrf"].Value = salario_pos_irrf.ToString("N2");
                    }
                    else if (salario_2double < irrf3)
                    {
                        salario_pos_irrf = ((salario_2double / 100) * 15) - 354.80;
                        salario_liquido = salario_liquido = Convert.ToDecimal(salario_2double - salario_pos_irrf);
                        linha.Cells["salario_liquido"].Value = salario_liquido.ToString("N2");
                        linha.Cells["desconto_irrf"].Value = salario_pos_irrf.ToString("N2");
                    }
                    else if (salario_2double < irrf4)
                    {
                        salario_pos_irrf = ((salario_2double / 100) * 22.5) - 636.13;
                        salario_liquido = salario_liquido = Convert.ToDecimal(salario_2double - salario_pos_irrf);
                        linha.Cells["salario_liquido"].Value = salario_liquido.ToString("N2");
                        linha.Cells["desconto_irrf"].Value = salario_pos_irrf.ToString("N2");
                    }
                    else if (salario_2double >= irrf4)
                    {
                        salario_pos_irrf = ((salario_2double / 100) * 27.5) - 869.36;
                        salario_liquido = salario_liquido = Convert.ToDecimal(salario_2double - salario_pos_irrf);
                        linha.Cells["salario_liquido"].Value = salario_liquido.ToString("N2");
                        linha.Cells["desconto_irrf"].Value = salario_pos_irrf.ToString("N2");
                    }

                }

            }
            catch { } Exception ex;
        }

        private void btnRegFolha_Click(object sender, EventArgs e)
        {
            var connString = @"Server=localhost;Port=5432;User Id=postgres;Password=admin;Database=local";
            NpgsqlConnection conn = null;
            NpgsqlCommand cmd = null;

            conn = new NpgsqlConnection(connString);
            conn.Open();

            var primeiraLinha = dataGridView1.Rows[0]; // Obtém a primeira linha do DataGridView

            var competencia = primeiraLinha.Cells["Competencia"].Value.ToString();
            //var matricula = Convert.ToInt32(primeiraLinha.Cells["Matricula"].Value);

            // Verificar se já existe um registro com a mesma competência e ID_FUNC
            var existsSql = "SELECT COUNT(*) FROM FOLHA_PAG WHERE competencia = @Competencia";
            cmd = new NpgsqlCommand(existsSql, conn);
            cmd.Parameters.AddWithValue("Competencia", competencia);
            //cmd.Parameters.AddWithValue("Matricula", matricula);

            int rowCount = Convert.ToInt32(cmd.ExecuteScalar());
            if (rowCount > 0)
            {
                var confirmResult = MessageBox.Show($"Os dados já existem na tabela FOLHA DE PAGAMENTO COMPETÊNCIA : {competencia} . Deseja prosseguir com a inserção?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (confirmResult == DialogResult.No)
                {
                    // Cancelar o processamento e retornar à tela anterior
                    return;
                }
                else
                {
                    // Excluir todas as linhas correspondentes à competência
                    var deleteSql = "DELETE FROM FOLHA_PAG WHERE competencia = @Competencia";
                    cmd = new NpgsqlCommand(deleteSql, conn);
                    cmd.Parameters.AddWithValue("Competencia", competencia);
                    cmd.ExecuteNonQuery();
                }
            }
            try
            {
                foreach (DataGridViewRow linha in dataGridView1.Rows)
                {
                    var salarioBase = Convert.ToDouble(linha.Cells["salario_base"].Value);
                    var taxaHora = Convert.ToDecimal(linha.Cells["taxa_hora"].Value);
                    var matricula = Convert.ToDecimal(linha.Cells["matricula"].Value);
                    var horasTrabalhadas = Convert.ToDecimal(linha.Cells["horas_trabalhadas"].Value);
                    var horasNormais = Convert.ToDecimal(linha.Cells["horas_normais"].Value);
                    var horasExtra = Convert.ToDecimal(linha.Cells["horas_extras"].Value);
                    var descontoInss = Convert.ToDecimal(linha.Cells["desconto_inss"].Value);
                    var descontoIrrf = Convert.ToDecimal(linha.Cells["desconto_irrf"].Value);
                    var salarioLiquido = Convert.ToDecimal(linha.Cells["salario_liquido"].Value);

                    var insertSql = "INSERT INTO FOLHA_PAG (competencia, id_func, sal_base, taxa_hora, hora_trab, hora_norm, hora_extr, inss_desc, irrf_desc, sal_liqu) VALUES (@Competencia, @Matricula, @SalarioBase, @TaxaHora, @HorasTrabalhadas, @HorasNormais, @HorasExtra, @DescontoInss, @DescontoIrrf, @SalarioLiquido)";
                    cmd = new NpgsqlCommand(insertSql, conn);
                    cmd.Parameters.AddWithValue("Competencia", competencia);
                    cmd.Parameters.AddWithValue("Matricula", matricula);
                    cmd.Parameters.AddWithValue("SalarioBase", salarioBase);
                    cmd.Parameters.AddWithValue("TaxaHora", taxaHora);
                    cmd.Parameters.AddWithValue("HorasTrabalhadas", horasTrabalhadas);
                    cmd.Parameters.AddWithValue("HorasNormais", horasNormais);
                    cmd.Parameters.AddWithValue("HorasExtra", horasExtra);
                    cmd.Parameters.AddWithValue("DescontoInss", descontoInss);
                    cmd.Parameters.AddWithValue("DescontoIrrf", descontoIrrf);
                    cmd.Parameters.AddWithValue("SalarioLiquido", salarioLiquido);
                    cmd.ExecuteNonQuery();

                    // Limpar o DataGrid
                    //dataGridView1.Rows.Clear();
                    //dataGridView1.Refresh();

                }
                // Mostrar mensagem de sucesso
                

                
            }
            catch (Exception ex) { }
            finally 
            {
                MessageBox.Show("Registro de Folha Gravado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
