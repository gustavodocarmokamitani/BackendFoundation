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

        [HttpGet]
        public ActionResult<IEnumerable<Agendamento>> Get()
        {
            return Ok(_dbContext.Agendamentos.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Agendamento> GetById(int id)
        {
            var agendamento = _dbContext.Agendamentos.Find(id);
            if (agendamento == null) return NotFound();
            return Ok(agendamento);
        }

        [HttpPost]
        public ActionResult<Agendamento> Post([FromBody] Agendamento agendamento)
        {
            if (agendamento == null) return BadRequest("Dados inválidos");
            _dbContext.Agendamentos.Add(agendamento);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = agendamento.Id }, agendamento);
        }

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
