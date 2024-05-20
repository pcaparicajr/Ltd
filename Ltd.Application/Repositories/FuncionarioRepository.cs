using Ltd.Application.Interfaces;
using Ltd.Domain.Entities;
using Ltd.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.Application.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        public readonly ApplicationDbContext _context;


        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Alterar(Funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
        }

        public void Excluir(Funcionario funcionario)
        {
            _context.Remove(funcionario);
        }

        public void Incluir(Funcionario funcionario)
        {
            _context.Add(funcionario);
        }

        public async Task<bool> SaveAllAssinc()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Funcionario> SelecionarByPk(int id)
        {
            var funcionario = await _context.Funcionario.Where(x => x.Id == id).FirstOrDefaultAsync();
            return funcionario;
        }

        public async Task<IEnumerable<Funcionario>> SelecionarTodos()
        {
            return await _context.Funcionario.ToListAsync();
        }
    }
}
