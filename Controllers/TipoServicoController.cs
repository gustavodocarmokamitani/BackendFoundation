using backend.Models; 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoServicoController : ControllerBase
    {
        private readonly SalaoContext _dbContext;

        public TipoServicoController(SalaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/tiposservico
        [HttpGet]
        public ActionResult<IEnumerable<TipoServico>> Get()
        {
            return Ok(_dbContext.TipoServicos.ToList());
        }

        // GET: api/tiposservico/{id}
        [HttpGet("{id}")]
        public ActionResult<TipoServico> GetById(int id)
        {
            var tipoServico = _dbContext.TipoServicos.Find(id);
            if (tipoServico == null) return NotFound();
            return Ok(tipoServico);
        }

        // POST: api/tiposservico
        [HttpPost]
        public ActionResult<List<TipoServico>> Post([FromBody] List<TipoServico> tiposServico)
        {
            if (tiposServico == null || !tiposServico.Any())
            {
                return BadRequest("Dados inválidos");
            }

            var tiposServicoParaAdicionar = new List<TipoServico>();

            foreach (var tipoServico in tiposServico)
            {
                // Adiciona o TipoServico ao banco de dados
                _dbContext.TipoServicos.Add(tipoServico);
                tiposServicoParaAdicionar.Add(tipoServico);
            }

            _dbContext.SaveChanges(); // Salva para gerar os Ids dos TipoServicos

            // Agora cria os Servicos correspondentes para cada TipoServico
            foreach (var tipoServico in tiposServicoParaAdicionar)
            {
                var servico = new Servico
                {
                    TipoServicoId = tipoServico.Id,
                    // Inicializa outros campos de Servico se necessário
                };

                _dbContext.Servicos.Add(servico);
            }

            _dbContext.SaveChanges(); // Salva todos os Servicos adicionados

            return CreatedAtAction(nameof(Get), tiposServicoParaAdicionar); // Retorna todos os TipoServicos adicionados
        }

        // PUT: api/tiposservico/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoServico tipoServico)
        {
            if (tipoServico == null || id != tipoServico.Id) return BadRequest("Dados inválidos");
            var existingTipoServico = _dbContext.TipoServicos.Find(id);
            if (existingTipoServico == null) return NotFound();
            _dbContext.Entry(existingTipoServico).CurrentValues.SetValues(tipoServico);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/tiposservico/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tipoServico = _dbContext.TipoServicos.Find(id);
            if (tipoServico == null) return NotFound();
            _dbContext.TipoServicos.Remove(tipoServico);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
