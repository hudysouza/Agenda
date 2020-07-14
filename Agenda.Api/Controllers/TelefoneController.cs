using System.Linq;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefoneController : ControllerBase
    {
        protected AgendaDbContext _agendaDbContext;
        protected DbSet<Telefone> _dbSet;

        public TelefoneController(AgendaDbContext agendaDbContext)
        {
            _agendaDbContext = agendaDbContext;
            _dbSet = agendaDbContext.Set<Telefone>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var telefones = _dbSet.ToList();
            return Ok(telefones);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var telefone = _dbSet.FirstOrDefault(o => o.Id == id);

            if (telefone != null)
                return Ok(telefone);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Telefone telefone)
        {
            try
            {
                telefone.Id = 0;

                _dbSet.Add(telefone);

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
            var telefone = _dbSet.FirstOrDefault(o => o.Id == id);

            if (telefone == null)
                return NoContent();

            _dbSet.Remove(telefone);

            _agendaDbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Telefone telefone)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                telefone.Id = id;
                _dbSet.Update(telefone);

                _agendaDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}