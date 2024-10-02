using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CabeleireiroController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public CabeleireiroController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cabeleireiro>> Get()
        {
            return Ok(_dbContext.Cabeleireiros.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Cabeleireiro> GetById(int id)
        {
            var cabeleireiro = _dbContext.Cabeleireiros.Find(id);
            if (cabeleireiro == null) return NotFound();
            return Ok(cabeleireiro);
        }

        [HttpPost]
        public ActionResult<Cabeleireiro> Post([FromBody] Cabeleireiro cabeleireiro)
        {
            if (cabeleireiro == null) return BadRequest("Dados inválidos");
            _dbContext.Cabeleireiros.Add(cabeleireiro);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = cabeleireiro.Id }, cabeleireiro);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cabeleireiro cabeleireiro)
        {
            if (cabeleireiro == null || id != cabeleireiro.Id) return BadRequest("Dados inválidos");
            var existingCabeleireiro = _dbContext.Cabeleireiros.Find(id);
            if (existingCabeleireiro == null) return NotFound();
            _dbContext.Entry(existingCabeleireiro).CurrentValues.SetValues(cabeleireiro);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cabeleireiro = _dbContext.Cabeleireiros.Find(id);
            if (cabeleireiro == null) return NotFound();
            _dbContext.Cabeleireiros.Remove(cabeleireiro);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
