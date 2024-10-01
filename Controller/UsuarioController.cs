using backend.Context;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public UsuarioController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _dbContext.Usuarios.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Dados inválidos");
            }
            usuario.Confirmado = false;

            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.Id)
            {
                return BadRequest("Dados inválidos");
            }

            var existingUsuario = _dbContext.Usuarios.Find(id);

            if (existingUsuario == null)
            {
                return NotFound();
            }

            // Copiar todas as propriedades do objeto recebido para o objeto existente, exceto o Id
            _dbContext.Entry(existingUsuario).CurrentValues.SetValues(usuario);
            _dbContext.Entry(existingUsuario).Property(x => x.Id).IsModified = false;

            // Salvar as alterações no banco de dados
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpGet("confirmados")]
        public IEnumerable<Usuario> GetConfirmados()
        {
            var usuariosConfirmados = _dbContext.Usuarios.Where(u => u.Confirmado).ToList();
            return usuariosConfirmados;
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _dbContext.Usuarios.Remove(usuario);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
