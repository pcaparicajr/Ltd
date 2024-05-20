using Ltd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.Application.Interfaces
{
    public interface IFuncionarioRepository
    {
        void Incluir(Funcionario funcionario);
        void Alterar(Funcionario funcionario);
        void Excluir(Funcionario funcionario);
        Task<Funcionario> SelecionarByPk(int id);
        Task<IEnumerable<Funcionario>> SelecionarTodos();
        Task<bool> SaveAllAssinc();
    }
}
