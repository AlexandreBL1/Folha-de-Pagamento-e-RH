using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using NpgsqlTypes;

namespace Folha_Pagamentos_01_Inicio
{
    public  class BD
    {
        public static string func_nome;
        public string comandoSQL;
        public static int id_func;
        public static NpgsqlConnection GetConnection()
        {
            //Localização do banco
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=dbadmin;Database=local");
        }



        public static void InsertCadastro(string nome,
                                            string cpf,
                                            string email,
                                            string senha,
                                            string telefone,
                                            DateTime data_nasc,
                                            DateTime dat_adm,
                                            string depto,
                                            string cargo,
                                            string status,
                                            decimal sal_base)
        {
           
                using (NpgsqlConnection con = GetConnection())
                {
                    string query = "INSERT INTO FUNCIONARIO (nome_func, cpf, email, senha, telefone, dt_nasc, dt_adm, depto, cargo, status, salario_base) VALUES (@nome, @cpf, @email, @senha, @telefone, @dt_nasc, @dt_adm, @depto, @cargo, @status, @sal_base)";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@email", email); ;
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@dt_nasc", data_nasc);
                    cmd.Parameters.AddWithValue("@dt_adm", dat_adm);
                    cmd.Parameters.AddWithValue("@depto", depto);
                    cmd.Parameters.AddWithValue("@cargo", cargo);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@sal_base", sal_base);

                    con.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n == 1)
                    {
                        Console.WriteLine("Insert");
                    } 
                }
        }
        [STAThread]
        public static void InsertEndereço(string nome, string cpf)
        {


            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();
                string cmdSeleciona = $@"SELECT * FROM funcionario where nome_func=@nome and cpf=@cpf ;";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdSeleciona, con);

                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cpf", cpf);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        //Irá buscar o id do funcionario
                        if (reader.GetInt32(0).ToString() != null)
                        {

                            id_func = reader.GetInt32(0);

                        }

                    }
                    
                }
               try
                {
                    if (id_func.ToString() != null)
                     {
                        
                        string query = "INSERT INTO ENDERECO (id_func,rua,numero,cidade,complemento,estado,cep) VALUES (@id_func,@rua,@numero,@cidade,@complemento,@estado,@cep)";
                          

                        NpgsqlCommand cmd1 = new NpgsqlCommand(query, con);
                        cmd1.Parameters.AddWithValue("@id_func", (int)id_func);
                        cmd1.Parameters.AddWithValue("@rua",FrmCadastrarEndereco.Endereço);
                        cmd1.Parameters.AddWithValue("@numero",FrmCadastrarEndereco.N);
                        cmd1.Parameters.AddWithValue("@cidade", FrmCadastrarEndereco.Cidade); ;
                        cmd1.Parameters.AddWithValue("@complemento", FrmCadastrarEndereco.Complemento);
                        cmd1.Parameters.AddWithValue("@estado", FrmCadastrarEndereco.Estado);
                        cmd1.Parameters.AddWithValue("@cep", FrmCadastrarEndereco.Cep);



                        int n = cmd1.ExecuteNonQuery();
                        if (n == 1)
                        {
                            Console.WriteLine("Insert");
                        }
                    }

                }
               catch (Exception ex) { }
            }
        }


        public static List<Funcionario> Listar(string nome)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
             using (NpgsqlConnection con = GetConnection())
            {
                string query = "SELECT id_func, nome_func , telefone, email, cpf, dt_nasc, dt_adm, salario_base, depto, cargo, status FROM funcionario WHERE nome_func ILIKE '%' || @nome || '%' and status = 'Ativo' order by nome_func ";
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           Funcionario func = new Funcionario();
                            func.Matricula = (int)reader["id_func"];
                            func.Nome = reader["nome_func"].ToString();
                            func.Telefone = reader["telefone"].ToString();
                            func.Email = reader["email"].ToString();
                            func.cpf = reader["cpf"].ToString();
                            func.dt_nasc = reader["dt_nasc"].ToString();
                            func.dt_adm = reader["dt_adm"].ToString();
                            func.salario_base = reader["salario_base"].ToString();
                            func.depto = reader["depto"].ToString();
                            func.cargo = reader["cargo"].ToString();
                            func.status = reader["status"].ToString();

                            funcionarios.Add(func);
                        }
                    }
                }
            }
            return funcionarios;
        }





        public static List<Funcionario> ListarInativos(string nome)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "SELECT id_func, nome_func , telefone, email, cpf, dt_nasc, dt_adm, salario_base, depto, cargo, status FROM funcionario WHERE nome_func ILIKE '%' || @nome || '%' and status = 'Inativo' order by nome_func ";
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Funcionario func = new Funcionario();
                            func.Matricula = (int)reader["id_func"];
                            func.Nome = reader["nome_func"].ToString();
                            func.Telefone = reader["telefone"].ToString();
                            func.Email = reader["email"].ToString();
                            func.cpf = reader["cpf"].ToString();
                            func.dt_nasc = reader["dt_nasc"].ToString();
                            func.dt_adm = reader["dt_adm"].ToString();
                            func.salario_base = reader["salario_base"].ToString();
                            func.depto = reader["depto"].ToString();
                            func.cargo = reader["cargo"].ToString();
                            func.status = reader["status"].ToString();

                            funcionarios.Add(func);
                        }
                    }
                }
            }
            return funcionarios;
        }





        public static bool GetRegistroAdmin(string cpf, string senha)
        {

            using (NpgsqlConnection con = GetConnection())
            {
                //Abre a conexão com o PgSQL
                con.Open();
                string cmdSeleciona = $@"SELECT * FROM user_pim where login =@cpf and senha =@senha and nivel_ac ='admin';";

                using (NpgsqlCommand cmd = new NpgsqlCommand(cmdSeleciona, con))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool resultado = false;

                        while (reader.Read())
                        {
                            if (reader.GetString(1) != null && reader.GetString(2) != null)
                            {
                                resultado = true;
                            }

                        }
                        return resultado;
                    }
                }

            }
        }
        public static bool GetRegistroUser(string cpf, string senha)
        {

            using (NpgsqlConnection con = GetConnection())
            {
                //Abre a conexão com o PgSQL
                con.Open();
                string cmdSeleciona = $@"SELECT * FROM funcionario where cpf =@cpf and senha =@senha;";

                using (NpgsqlCommand cmd = new NpgsqlCommand(cmdSeleciona, con))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool resultado = false;

                        while (reader.Read())
                        {
                            if (reader.GetString(2) != null && reader.GetString(4) != null)
                            {
                                resultado = true;
                            }

                        }
                        return resultado;
                    }
                }

            }
        }


        public static List<Salario> HorasFunc(string comp)
        {
            List<Salario> Salario = new List<Salario>();
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "SELECT pn.competencia, f.id_func, f.nome_func, F.salario_base, ROUND((f.salario_base / 160)::numeric, 2) AS Taxa_hora, sum(ROUND(EXTRACT(HOUR FROM pn.horas_trab) + EXTRACT(MINUTE FROM pn.horas_trab) / 60.0 + EXTRACT(SECOND FROM pn.horas_trab) / 3600.0, 2)) AS horas_trabalhadas, sum(ROUND(EXTRACT(HOUR FROM pn.horas_prev) + EXTRACT(MINUTE FROM pn.horas_prev) / 60.0 + EXTRACT(SECOND FROM pn.horas_prev) / 3600.0, 2)) AS horas_normais, sum(ROUND(EXTRACT(HOUR FROM pn.horas_extra) + EXTRACT(MINUTE FROM pn.horas_extra) / 60.0 + EXTRACT(SECOND FROM pn.horas_extra) / 3600.0, 2)) AS horas_extras FROM FUNCIONARIO f JOIN PONTO pn ON f.id_func = pn.id_func where pn.competencia = @comp group by pn.competencia, f.id_func, f.nome_func";

                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@comp", comp);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Salario func = new Salario();
                            func.competencia = reader["competencia"].ToString();
                            func.Matricula = (int)reader["id_func"];
                            func.Nome = reader["nome_func"].ToString();
                            func.Salario_Bruto = (double)reader["salario_base"];
                            func.taxa_hora = (decimal)reader["taxa_hora"];
                            func.horas_trabalhadas = (decimal)reader["horas_trabalhadas"];
                            func.horas_normais = (decimal)reader["horas_normais"];
                            func.horas_extra = (decimal)reader["horas_extras"];
                            //func.salario_base = reader["salario_base"].ToString();
                            //func.depto = reader["depto"].ToString();
                            //func.cargo = reader["cargo"].ToString();
                            //func.status = reader["status"].ToString();

                            Salario.Add(func);
                        }



                    }
                }
            }
            return Salario;
        }





        public static List<Salario> FolhaPag(string comp, int matricula)
        {
            List<Salario> Salario = new List<Salario>();
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "select fp.competencia, f.id_func, f.nome_func, fp.taxa_hora, fp.hora_trab, fp.hora_norm, fp.hora_extr, fp.inss_desc, fp.irrf_desc, fp.sal_liqu from folha_pag fp join funcionario f on fp.id_func = f.id_func where competencia = @comp and f.id_func = @matricula";

                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@comp", comp);
                    cmd.Parameters.AddWithValue("@matricula", matricula);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Salario func = new Salario();
                            func.competencia = reader["competencia"].ToString();
                            func.Matricula = (int)reader["id_func"];
                            func.Nome = reader["nome_func"].ToString();
                            //func.Salario_Bruto = (double)reader["salario_base"];
                            func.taxa_hora = Convert.ToDecimal((double)reader["taxa_hora"]);
                            func.horas_trabalhadas = Convert.ToDecimal((double)reader["hora_trab"]);
                            func.horas_normais = Convert.ToDecimal((double)reader["hora_norm"]);
                            func.horas_extra = Convert.ToDecimal((double)reader["hora_extr"]);
                            func.inss_desc = Convert.ToDecimal((double)reader["inss_desc"]);
                            func.irrf_desc = Convert.ToDecimal((double)reader["irrf_desc"]);
                            func.sal_liquido = Convert.ToDecimal((double)reader["sal_liqu"]);
                            //func.salario_base = reader["salario_base"].ToString();
                            //func.depto = reader["depto"].ToString();
                            //func.cargo = reader["cargo"].ToString();
                            //func.status = reader["status"].ToString();

                            Salario.Add(func);
                        }



                    }
                }
            }
            return Salario;
        }








    }
}
