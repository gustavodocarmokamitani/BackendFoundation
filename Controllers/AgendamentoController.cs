using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public AgendamentoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obter todos os agendamentos
        [HttpGet]
        public ActionResult<IEnumerable<Agendamento>> Get()
        {
            return Ok(_dbContext.Agendamentos.ToList());
        }

        // Obter agendamento por ID
        [HttpGet("{id}")]
        public ActionResult<Agendamento> GetById(int id)
        {
            var agendamento = _dbContext.Agendamentos.Find(id);
            if (agendamento == null) return NotFound();
            return Ok(agendamento);
        }

        // Criar um novo agendamento
        [HttpPost]
        public ActionResult<Agendamento> Post([FromBody] Agendamento agendamento)
        {
            if (agendamento == null) return BadRequest("Dados inválidos");

            // Verifica se o ClienteId existe
            var cliente = _dbContext.Usuarios.Find(agendamento.ClienteId);
            if (cliente == null)
            {
                return BadRequest($"Cliente com ID {agendamento.ClienteId} não encontrado.");
            }

            // Verifica se o CabeleleiroId existe
            var cabeleireiro = _dbContext.Cabeleleiros.Find(agendamento.
                Id);
            if (cabeleireiro == null)
            {
                return BadRequest($"Cabeleleiro com ID {agendamento.CabeleleiroId} não encontrado.");
            }

            // Verifica se o ServicoId existe
            var servico = _dbContext.Servicos.Find(agendamento.ServicoId);
            if (servico == null)
            {
                return BadRequest($"Serviço com ID {agendamento.ServicoId} não encontrado.");
            }

            // Se todos os IDs forem válidos, adiciona o agendamento
            _dbContext.Agendamentos.Add(agendamento);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = agendamento.Id }, agendamento);
        }

        // Atualizar um agendamento existente
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Agendamento agendamento)
        {
            if (agendamento == null || id != agendamento.Id) return BadRequest("Dados inválidos");
            var existingAgendamento = _dbContext.Agendamentos.Find(id);
            if (existingAgendamento == null) return NotFound();
            _dbContext.Entry(existingAgendamento).CurrentValues.SetValues(agendamento);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // Deletar um agendamento
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var agendamento = _dbContext.Agendamentos.Find(id);
            if (agendamento == null) return NotFound();
            _dbContext.Agendamentos.Remove(agendamento);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
