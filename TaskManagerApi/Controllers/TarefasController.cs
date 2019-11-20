using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskManagerApi.Models;

namespace TaskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TarefasController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/Tarefas
        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> Get()
        {
            return await _dbContext.Tarefas.ToListAsync();
        }

        // GET api/Tarefas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> Get(string id)
        {
            return await _dbContext.Tarefas.FindAsync(id);
        }

        // POST api/Tarefas
        [HttpPost]
        public async Task Post(Tarefa model)
        {
            //Tarefa model = new Tarefa() { Descricao = tarefa.Descricao, Titulo = tarefa.Titulo };
            var XX = await _dbContext.Tarefas.MaxAsync(f => f.Id);
            model.DataCriacao = System.DateTime.Now; 
            await _dbContext.AddAsync(model);

            await _dbContext.SaveChangesAsync();
        }

        // PUT api/Tarefas/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, Tarefa model)
        {
            var exists = await _dbContext.Tarefas.AnyAsync(f => f.Id.Equals(id));
            if (!exists)
            {
                return NotFound();
            }

            model.DataAlteracao = System.DateTime.Now;
            _dbContext.Tarefas.Update(model);

            await _dbContext.SaveChangesAsync();

            return Ok();

        }

        // DELETE api/Tarefas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _dbContext.Tarefas.FindAsync(id);

            _dbContext.Tarefas.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }

    public class TarefaView
    {
        public string Descricao { get; set; }
        public string Titulo { get; set; }
    }
}