using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Folha_Pagamentos_01_Inicio
{
    public class Salario : Funcionario
    {
        public string competencia { get; set; }
        public int matricula { get; set; }
        public string nome_func { get; set; }

        public double Salario_Bruto { get; set; }
        public decimal Salario_brutal { get; set; }
        public decimal Salario_Liquido { get; set; }
        public decimal descontos { get; set; }
        public decimal Impostos { get; set; }
        public decimal horas_normais { get; set; }
        public decimal horas_extra { get; set; }
        public decimal taxa_hora { get; set; }
        public decimal horas_trabalhadas { get; set; }
        public decimal inss_desc { get; set; }
        public decimal irrf_desc { get; set; }
        public decimal sal_liquido { get; set; }
        public string login_func { get; set; }


        public int matricula_func, id_end, id_func2;
        public string nome, cpf, email, senha, tel, depto, cargo, status, rua, numero, cidade, estado, complemento, cep;
        public decimal salario_funuc;
        DateTime dt_nasc, dt_adm;




        public void DadosFunc(string login_func)
        {
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
                                matricula = dt.GetInt32(0);
                                nome = dt.GetString(1);
                                cpf = dt.GetString(2);
                                email = dt.GetString(3);
                                senha = dt.GetString(4);
                                tel = dt.GetString(5);
                                dt_nasc = dt.GetDateTime(6);
                                dt_adm = dt.GetDateTime(7);
                                salario_funuc = dt.GetDecimal(8);
                                depto = dt.GetString(9);
                                cargo = dt.GetString(10);
                                status = dt.GetString(11);
                                id_end = dt.GetInt32(12);
                                id_func2 = dt.GetInt32(13);
                                rua = dt.GetString(14);
                                numero = dt.GetString(15);
                                cidade = dt.GetString(16);
                                estado = dt.GetString(17);
                                cep = dt.GetString(18);
                                complemento = dt.GetString(19);





                            }
                        }
                    }
                }
            }
        }

    }
}
