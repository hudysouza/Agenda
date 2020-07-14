using System.Linq;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        protected AgendaDbContext _agendaDbContext;
        protected DbSet<Pessoa> _dbSet;

        public PessoaController(AgendaDbContext agendaDbContext)
        {
            _agendaDbContext = agendaDbContext;
            _dbSet = agendaDbContext.Set<Pessoa>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pessoas = _dbSet.Include(o => o.Endereco)
                .Include(o => o.Telefones)
                .ToList();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pessoa = _dbSet.Include(o => o.Endereco)
                .Include(o => o.Telefones)
                .FirstOrDefault(o => o.Id == id);

            if (pessoa != null)
                return Ok(pessoa);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            try
            {
                pessoa.Id = 0;

                _dbSet.Add(pessoa);

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
            var pessoa = _dbSet.FirstOrDefault(o => o.Id == id);

            if (pessoa == null)
                return NoContent();

            _dbSet.Remove(pessoa);

            _agendaDbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                pessoa.Id = id;
                _dbSet.Update(pessoa);

                _agendaDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}