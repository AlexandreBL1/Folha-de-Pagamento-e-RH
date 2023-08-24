using Npgsql;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace Folha_Pagamentos_01_Inicio
{
    public partial class FrmApontamento : Form
        
    {
        public void ExibirDadosPonto()
        {
            string connectionString = (@"Server=localhost;Port=5432;User Id=postgres;Password=dbadmin;Database=local");
            

            string sql = "SELECT f.nome_func, p.* FROM funcionario f JOIN ponto p on f.id_func = p.id_func";


            using (NpgsqlConnection conn = BD.GetConnection())
            {
                conn.Open();

                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    /*
                    try
                    {
                        dataGridView1.Columns["f.nome_func"].HeaderText = "Nome Funcionario";
                        dataGridView1.Columns["p.id_func"].HeaderText = "Matricula";
                        dataGridView1.Columns["p.data_entrada"].HeaderText = "Data Entrada";
                        dataGridView1.Columns["p.hora_entrada"].HeaderText = "Hora Entrada";
                        dataGridView1.Columns["p.data_saida"].HeaderText = "Data Saída";
                        dataGridView1.Columns["p.hora_saida"].HeaderText = "Hora Saída";
                        dataGridView1.Columns["p.intervalo"].HeaderText = "Intervalo";
                        dataGridView1.Columns["p.horas_trab"].HeaderText = "Horas Trabalhadas";
                        dataGridView1.Columns["p.horas_prev"].HeaderText = "Horas Previstas";
                        dataGridView1.Columns["p.horas_extra"].HeaderText = "Horas Extras";

                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show("Ocorreu um erro ao exibir os dados da tabela Ponto: " + ex.Message);
                    }

                    */
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }

        public FrmApontamento()
        {
            InitializeComponent();
            
        }

        public void FrmApontamento_Load(object sender, EventArgs e)
        {
            ExibirDadosPonto();
            PreencherFuncionarios();
            PreencherGrid();

        }



        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       


        public void PreencherFuncionarios()
        {
            
            string connectionString = (@"Server=localhost;Port=5432;User Id=postgres;Password=dbadmin;Database=local");
            string sql = "SELECT id_func,nome_func FROM Funcionario ORDER BY nome_func";
            
            using (NpgsqlConnection conn = BD.GetConnection())
            {
                conn.Open();

                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox1.DisplayMember = "nome_func";
                    comboBox1.ValueMember = "id_func";
                    comboBox1.DataSource = dt;

                    DataRow dr = dt.NewRow();
                    dr["id_func"] = 0;
                    dr["nome_func"] = "Todos";
                    dt.Rows.InsertAt(dr, 0);
                    comboBox1.SelectedValue = 0;
                }
            }
        }

        private void PreencherGrid()
        {
            using (var conn = BD.GetConnection())
            {

                conn.Open();

                string query = "SELECT f.nome_func, p.* FROM funcionario f " +
                    "INNER JOIN ponto p ON f.id_func = p.id_func ";

                if (comboBox1.SelectedValue != null && (int)comboBox1.SelectedValue != 0)
                {
                    query += " WHERE f.nome_func = @funcionario";
                }


                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (comboBox1.SelectedValue != null && (int)comboBox1.SelectedValue != 0)
                    {
                        cmd.Parameters.AddWithValue("funcionario", comboBox1.SelectedValue);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;


                    }
                }
            }
        }



        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int idFuncionario = (int)comboBox1.SelectedValue;

                if (idFuncionario == 0) // Verifica se a opção "Todos" foi selecionada
                {
                    ExibirDadosPonto(); // Exibe todos os dados novamente
                }
                else // Executa a consulta baseada no valor selecionado atualmente
                {
                    string connectionString = (@"Server=localhost;Port=5432;User Id=postgres;Password=dbadmin;Database=local");
                    string sql = $"SELECT f.nome_func, p.* FROM funcionario f JOIN ponto p on f.id_func = p.id_func WHERE p.id_func = {idFuncionario}";

                    using (NpgsqlConnection conn = BD.GetConnection())
                    {
                        conn.Open();

                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dataGridView1.DataSource = dt;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        }
                    }
                }
            }
        }

        public void btnExportarExcell_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Arquivo Excel|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Dados");
                    try
                    {
                        for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                        {
                            worksheet.Cells[1, i].Value = dataGridView1.Columns[i - 1].HeaderText;
                        }
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    catch { } Exception ex = null;
                    package.SaveAs(new FileInfo(sfd.FileName));
                }
            }

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
