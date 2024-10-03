using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusPagamentoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public StatusPagamentoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/tiposservico
        [HttpGet]
        public ActionResult<IEnumerable<StatusPagamento>> Get()
        {
            return Ok(_dbContext.StatusPagamentos.ToList());
        }

        // GET: api/tiposservico/{id}
        [HttpGet("{id}")]
        public ActionResult<StatusPagamento> GetById(int id)
        {
            var StatusPagamento = _dbContext.StatusPagamentos.Find(id);
            if (StatusPagamento == null) return NotFound();
            return Ok(StatusPagamento);
        }

        // POST: api/tiposservico
        [HttpPost]
        public ActionResult<StatusPagamento> Post([FromBody] StatusPagamento StatusPagamento)
        {
            if (StatusPagamento == null) return BadRequest("Dados inválidos");
            _dbContext.StatusPagamentos.Add(StatusPagamento);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = StatusPagamento.Id }, StatusPagamento);
        }

        // PUT: api/tiposservico/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatusPagamento StatusPagamento)
        {
            if (StatusPagamento == null || id != StatusPagamento.Id) return BadRequest("Dados inválidos");
            var existingStatusPagamento = _dbContext.StatusPagamentos.Find(id);
            if (existingStatusPagamento == null) return NotFound();
            _dbContext.Entry(existingStatusPagamento).CurrentValues.SetValues(StatusPagamento);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/tiposservico/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var StatusPagamento = _dbContext.StatusPagamentos.Find(id);
            if (StatusPagamento == null) return NotFound();
            _dbContext.StatusPagamentos.Remove(StatusPagamento);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
