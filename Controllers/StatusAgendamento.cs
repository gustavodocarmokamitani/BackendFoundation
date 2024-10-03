using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusAgendamentoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public StatusAgendamentoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/tiposservico
        [HttpGet]
        public ActionResult<IEnumerable<StatusAgendamento>> Get()
        {
            return Ok(_dbContext.StatusAgendamentos.ToList());
        }

        // GET: api/tiposservico/{id}
        [HttpGet("{id}")]
        public ActionResult<StatusAgendamento> GetById(int id)
        {
            var StatusAgendamento = _dbContext.StatusAgendamentos.Find(id);
            if (StatusAgendamento == null) return NotFound();
            return Ok(StatusAgendamento);
        }

        // POST: api/tiposservico
        [HttpPost]
        public ActionResult<StatusAgendamento> Post([FromBody] StatusAgendamento StatusAgendamento)
        {
            if (StatusAgendamento == null) return BadRequest("Dados inválidos");
            _dbContext.StatusAgendamentos.Add(StatusAgendamento);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = StatusAgendamento.Id }, StatusAgendamento);
        }

        // PUT: api/tiposservico/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatusAgendamento StatusAgendamento)
        {
            if (StatusAgendamento == null || id != StatusAgendamento.Id) return BadRequest("Dados inválidos");
            var existingStatusAgendamento = _dbContext.StatusAgendamentos.Find(id);
            if (existingStatusAgendamento == null) return NotFound();
            _dbContext.Entry(existingStatusAgendamento).CurrentValues.SetValues(StatusAgendamento);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/tiposservico/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var StatusAgendamento = _dbContext.StatusAgendamentos.Find(id);
            if (StatusAgendamento == null) return NotFound();
            _dbContext.StatusAgendamentos.Remove(StatusAgendamento);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
