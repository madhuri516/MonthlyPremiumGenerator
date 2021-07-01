using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmdApi.Models;

namespace CmdApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {

        private readonly CommandContext _context;

        public CommandController(CommandContext context) => _context = context;


        /*
       [HttpGet]
       public ActionResult<IEnumerable<string>> GetString()

       {
           return new string[] {"this", "is", "hard", "coded" };
       }
       */

        //GET:    api/command
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _context.CommandItems;
        }

        //GET:    api/command/n
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return commandItem;
        }

        //POST:   api/command
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();

            return CreatedAtAction("GetCommandItem", new Command { Id = command.Id }, command);
        }

        //PUT:     api/command/n
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();

        }

        //DELETE:   api/command/n
        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();

            }

            _context.CommandItems.Remove(commandItem);
            _context.SaveChanges();

            return commandItem;

        }
    }
}
