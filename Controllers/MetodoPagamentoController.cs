using backend.Models; // Importando o modelo de Método de Pagamento
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetodoPagamentoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public MetodoPagamentoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/metodopagamento
        [HttpGet]
        public ActionResult<IEnumerable<MetodoPagamento>> Get()
        {
            return Ok(_dbContext.MetodosPagamento.ToList());
        }

        // GET: api/metodopagamento/{id}
        [HttpGet("{id}")]
        public ActionResult<MetodoPagamento> GetById(int id)
        {
            var metodoPagamento = _dbContext.MetodosPagamento.Find(id);
            if (metodoPagamento == null) return NotFound();
            return Ok(metodoPagamento);
        }

        // POST: api/metodopagamento
        [HttpPost]
        public ActionResult<List<MetodoPagamento>> Post([FromBody] List<MetodoPagamento> metodosPagamento)
        {
            if (metodosPagamento == null || !metodosPagamento.Any())
            {
                return BadRequest("Dados inválidos");
            }

            var metodosPagamentoParaAdicionar = new List<MetodoPagamento>();

            foreach (var metodoPagamento in metodosPagamento)
            {
                // Adiciona o MetodoPagamento ao banco de dados
                _dbContext.MetodosPagamento.Add(metodoPagamento);
                metodosPagamentoParaAdicionar.Add(metodoPagamento);
            }

            _dbContext.SaveChanges(); // Salva para gerar os Ids dos MetodosPagamento

            return CreatedAtAction(nameof(Get), metodosPagamentoParaAdicionar); // Retorna todos os MetodosPagamento adicionados
        }

        // PUT: api/metodopagamento/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MetodoPagamento metodoPagamento)
        {
            if (metodoPagamento == null || id != metodoPagamento.Id) return BadRequest("Dados inválidos");
            var existingMetodoPagamento = _dbContext.MetodosPagamento.Find(id);
            if (existingMetodoPagamento == null) return NotFound();
            _dbContext.Entry(existingMetodoPagamento).CurrentValues.SetValues(metodoPagamento);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/metodopagamento/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var metodoPagamento = _dbContext.MetodosPagamento.Find(id);
            if (metodoPagamento == null) return NotFound();
            _dbContext.MetodosPagamento.Remove(metodoPagamento);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
