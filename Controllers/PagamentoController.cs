using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public PagamentoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pagamento>> Get()
        {
            return Ok(_dbContext.Pagamentos.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Pagamento> GetById(int id)
        {
            var pagamento = _dbContext.Pagamentos.Find(id);
            if (pagamento == null) return NotFound();
            return Ok(pagamento);
        }

        [HttpPost]
        public ActionResult<List<Pagamento>> Post([FromBody] List<Pagamento> pagamentos)
        {
            if (pagamentos == null || !pagamentos.Any())
            {
                return BadRequest("Dados inválidos");
            }

            var pagamentosParaAdicionar = new List<Pagamento>();

            foreach (var pagamento in pagamentos)
            {
                // Verifica se o AgendamentoId existe
                var agendamento = _dbContext.Agendamentos.Find(pagamento.AgendamentoId);
                if (agendamento == null)
                {
                    return BadRequest($"Agendamento com ID {pagamento.AgendamentoId} não encontrado.");
                }

                // Adiciona o Pagamento ao banco de dados
                _dbContext.Pagamentos.Add(pagamento);
                pagamentosParaAdicionar.Add(pagamento);
            }

            _dbContext.SaveChanges(); // Salva para gerar os Ids dos Pagamentos

            return CreatedAtAction(nameof(Get), pagamentosParaAdicionar); // Retorna todos os Pagamentos adicionados
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pagamento pagamento)
        {
            if (pagamento == null || id != pagamento.Id) return BadRequest("Dados inválidos");
            var existingPagamento = _dbContext.Pagamentos.Find(id);
            if (existingPagamento == null) return NotFound();
            _dbContext.Entry(existingPagamento).CurrentValues.SetValues(pagamento);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pagamento = _dbContext.Pagamentos.Find(id);
            if (pagamento == null) return NotFound();
            _dbContext.Pagamentos.Remove(pagamento);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
