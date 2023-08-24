using Npgsql;
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
    public partial class FrmImportar : Form
    {
        public string comandoSQL;
        public FrmImportar()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            // Exibe o diálogo para selecionar o arquivo
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lê o arquivo selecionado e armazena seus dados em uma DataTable
                    DataTable dt = new DataTable();
                    string[] linhas = File.ReadAllLines(openFileDialog.FileName);


                    if (linhas.Length > 0)
                    {
                        // Adiciona as colunas da tabela
                        string[] cabecalho = linhas[0].Split(';');
                        foreach (string coluna in cabecalho)
                        {
                            dt.Columns.Add(coluna, typeof(string));
                        }

                        // Adiciona as linhas da tabela
                        for (int i = 1; i < linhas.Length; i++)
                        {
                            string[] dados = linhas[i].Split(';');
                            DataRow row = dt.NewRow();
                            for (int j = 0; j < cabecalho.Length; j++)
                            {
                                row[j] = dados[j];
                            }
                            dt.Rows.Add(row);
                        }
                    }

                    // Exibe os dados da tabela na tela
                    dgvDados.DataSource = dt;
                }
            }
        }

        public void InserirDados(DataTable dt)
        {

            // Configura a conexão com o banco de dados
            string connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=dbadmin;Database=local";
            using (NpgsqlConnection conexao = BD.GetConnection())


            {
                conexao.Open();

                // Define o nome da tabela onde os dados serão inseridos
                //string nomeTabela = "funcionario";
                string nomeTabela = comboBox1.SelectedItem.ToString();

                // Cria o comando SQL de inserção
                StringBuilder comandoSQL = new StringBuilder();
                comandoSQL.Append($"INSERT INTO {nomeTabela} (");

                // Adiciona os nomes das colunas
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    comandoSQL.Append($"{dt.Columns[i].ColumnName}");

                    if (i < dt.Columns.Count - 1)
                    {
                        comandoSQL.Append(", ");
                    }
                }

                comandoSQL.Append(") VALUES ");

                // Adiciona os valores das linhas
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comandoSQL.Append("(");

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        comandoSQL.Append($"'{dt.Rows[i][j].ToString()}'");

                        if (j < dt.Columns.Count - 1)
                        {
                            comandoSQL.Append(", ");
                        }
                    }

                    comandoSQL.Append(")");

                    if (i < dt.Rows.Count - 1)
                    {
                        comandoSQL.Append(", ");
                    }
                }

                comandoSQL.Append(";");

                // Executa o comando de inserção
                using (NpgsqlCommand comando = new NpgsqlCommand(comandoSQL.ToString(), conexao))

                    try
                    {
                        // Executa o comando de inserção
                        comando.ExecuteNonQuery();

                        // Limpa o datatable
                        dt.Clear();

                        // Exibe mensagem de sucesso
                        MessageBox.Show("Dados inseridos com sucesso!");

                        // Fecha o formulário
                        this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao inserir dados: {ex.Message}");
                    }

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exibe mensagem de confirmação caso o formulário esteja sendo fechado
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Deseja realmente fechar o formulário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvDados.DataSource as DataTable;
            InserirDados(dt);
        }

        private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmImportar_Load(object sender, EventArgs e)
        {

        }
    }
}
