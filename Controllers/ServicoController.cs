using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public ServicoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Servico>> Get()
        {
            return Ok(_dbContext.Servicos.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Servico> GetById(int id)
        {
            var servico = _dbContext.Servicos.Find(id);
            if (servico == null) return NotFound();
            return Ok(servico);
        }

        [HttpPost]
        public ActionResult<List<Servico>> Post([FromBody] List<Servico> servicos)
        {
            if (servicos == null || !servicos.Any())
            {
                return BadRequest("Dados inválidos");
            }

            var servicosParaAdicionar = new List<Servico>();

            foreach (var servico in servicos)
            {
                // Verifica se o TipoServicoId existe
                var tipoServico = _dbContext.TipoServicos.Find(servico.TipoServicoId);
                if (tipoServico == null)
                {
                    return BadRequest($"Tipo de serviço com ID {servico.TipoServicoId} não encontrado.");
                }

                // Adiciona o Servico ao banco de dados
                _dbContext.Servicos.Add(servico);
                servicosParaAdicionar.Add(servico);
            }

            _dbContext.SaveChanges(); // Salva para gerar os Ids dos Servicos

            return CreatedAtAction(nameof(Get), servicosParaAdicionar); // Retorna todos os Servicos adicionados
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Servico servico)
        {
            if (servico == null || id != servico.Id) return BadRequest("Dados inválidos");
            var existingServico = _dbContext.Servicos.Find(id);
            if (existingServico == null) return NotFound();
            _dbContext.Entry(existingServico).CurrentValues.SetValues(servico);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var servico = _dbContext.Servicos.Find(id);
            if (servico == null) return NotFound();
            _dbContext.Servicos.Remove(servico);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
