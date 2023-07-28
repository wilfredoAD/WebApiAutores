using ApiNew.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiNew.Controllers
{
    [ApiController]
    [Route("api/autors")]
    public class AutorsController: ControllerBase
    {
        private readonly ApplicationDbcontext context;

        public AutorsController(ApplicationDbcontext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Autor>> Get()
        {
            return await context.Autors.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {          
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        
        }    

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Autor autor, Guid id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
            }

            var existe = await context.Autors.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
