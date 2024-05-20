using Ltd.Application.Interfaces;
using Ltd.Application.Repositories;
using Ltd.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ltd.API.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
            return Ok(await _funcionarioRepository.SelecionarTodos());
        }
        [HttpPost]
        public async Task<ActionResult> CadastrarFuncionario(Funcionario funcionario)
        {
            _funcionarioRepository.Incluir(funcionario);
            if (await _funcionarioRepository.SaveAllAssinc())
            {
                return Ok("Funcionario cadastrado.");
            }
            return BadRequest("Erro ao cadastrar.");
        }
        [HttpPut]
        public async Task<ActionResult> AlteraFuncionario(Funcionario funcionario)
        {
            _funcionarioRepository.Alterar(funcionario);
            if (await _funcionarioRepository.SaveAllAssinc())
            {
                return Ok("Dados do funcionario alterados.");
            }
            return BadRequest("Erro ao alterar.");
        }
        [HttpDelete]
        public async Task<ActionResult> ExcluirFuncionario(Funcionario funcionario)
        {
            _funcionarioRepository.Excluir(funcionario);
            if (await _funcionarioRepository.SaveAllAssinc())
            {
                return Ok("Funcionario excluido.");
            }
            return BadRequest("Erro ao excluir.");
        }
    }
}
