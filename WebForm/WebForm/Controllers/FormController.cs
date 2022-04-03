using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebForm.Models;

namespace WebForm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormsController : ControllerBase
    {
        FormContext db;
        public FormsController(FormContext context)
        {
            db = context;
            if (!db.Form.Any())
            {
                db.Form.Add(new Form { Name = "Tom", Email = "tom@gmail.com", Phone ="89091009010", Topic="Support", Subject="I need help"});
                db.Form.Add(new Form { Name = "Alex", Email = "alex@gmail.com", Phone = "88005552200", Topic = "Support", Subject = "I need help too" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Form>>> Get()
        {
            return await db.Form.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Form>> Get(int id)
        {
            Form form = await db.Form.FirstOrDefaultAsync(x => x.Id == id);
            if (form == null)
                return NotFound();
            return new ObjectResult(form);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Form>> Post(Form form)
        {
            if (form == null)
            {
                return BadRequest();
            }

            db.Form.Add(form);
            await db.SaveChangesAsync();
            return Ok(form);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Form>> Put(Form form)
        {
            if (form == null)
            {
                return BadRequest();
            }
            if (!db.Form.Any(x => x.Id == form.Id))
            {
                return NotFound();
            }

            db.Update(form);
            await db.SaveChangesAsync();
            return Ok(form);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Form>> Delete(int id)
        {
            Form user = db.Form.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Form.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}