using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XPTO.Data;
using XPTO.Models;

namespace XPTO.Controllers
{
    [ApiController]
    [Route("v1/os")]
    public class OSController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<OS>>> Get([FromServices] DataContext context)
        {
            var osList = await context.OS.ToListAsync();
            return osList;
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<OS>> Post([FromServices] DataContext context, [FromBody] OS model)
        {
            model.OSNumber = Guid.NewGuid();
            model.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                context.OS.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult<List<OS>>> Put(Guid id, [FromBody] OS model, [FromServices] DataContext context)
        {
            if (id != model.OSNumber)
                return NotFound(new { message = "OS não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<OS>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar a OS" });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult<OS>> Delete([FromServices] DataContext context, Guid id)
        {
            var deletedOs = await context.OS.AsNoTracking().FirstOrDefaultAsync(x => x.OSNumber == id);
            context.OS.Remove(deletedOs);
            try
            {
                context.OS.Remove(deletedOs);
                await context.SaveChangesAsync();
                return Ok("OS removida com sucesso");
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a OS" });
            }
        }



    }
}