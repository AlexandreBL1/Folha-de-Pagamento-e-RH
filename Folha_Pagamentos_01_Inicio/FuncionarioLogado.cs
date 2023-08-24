using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Folha_Pagamentos_01_Inicio
{
    public static class FuncionarioLogado
    {
        public static string funcionario_cpf { get; set; }
        public static int funcionario_mat { get; set; }



        public static void pegarId(string cpf)
        {
            using (NpgsqlConnection con = BD.GetConnection())
            {
                con.Open();
                string query = "Select id_func from funcionario where cpf = @cpf";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                        using (NpgsqlDataReader dt = cmd.ExecuteReader())
                    {
                        if(dt.HasRows)
                        {
                            while (dt.Read())
                            {
                                funcionario_mat = dt.GetInt32(0);
                            }
                        }
                    }
                }
            }
        }
    }

}
