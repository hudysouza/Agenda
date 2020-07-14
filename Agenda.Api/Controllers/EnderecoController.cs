using System.Linq;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        protected AgendaDbContext _agendaDbContext;
        protected DbSet<Endereco> _dbSet;

        public EnderecoController(AgendaDbContext agendaDbContext)
        {
            _agendaDbContext = agendaDbContext;
            _dbSet = agendaDbContext.Set<Endereco>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var enderecos = _dbSet.ToList();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var endereco = _dbSet.FirstOrDefault(o => o.Id == id);

            if (endereco != null)
                return Ok(endereco);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Endereco endereco)
        {
            try
            {
                endereco.Id = 0;

                _dbSet.Add(endereco);

                _agendaDbContext.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { msg = "Erro ao executar operação" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var endereco = _dbSet.FirstOrDefault(o => o.Id == id);

            if (endereco == null)
                return NoContent();

            _dbSet.Remove(endereco);

            _agendaDbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Endereco endereco)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                endereco.Id = id;
                _dbSet.Update(endereco);

                _agendaDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}