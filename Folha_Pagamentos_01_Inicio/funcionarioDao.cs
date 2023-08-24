using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha_Pagamentos_01_Inicio
{
    public class funcionarioDao
    {
        public interface IFuncionarioDao
        {
            void Inserir(Funcionario funcionario);
            List<Funcionario> Listar();
            void Atualizar(Funcionario funcionario);
            void Remover(Funcionario funcionario);

            List<Salario> HorasFunc();
        }


    }
}
