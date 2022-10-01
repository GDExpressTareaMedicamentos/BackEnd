using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndDronMedicamento;
using BackEndDronMedicamento.Entidades;
using System.Text.RegularExpressions;

namespace BackEndDronMedicamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DronsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Drons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dron>>> GetDrones()
        {
            return await _context.Drones.ToListAsync();
        }

        // GET: api/Drons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dron>> GetDron(string id)
        {
            var dron = await _context.Drones.FindAsync(id);

            if (dron == null)
            {
                return NotFound();
            }

            return dron;
        }

        // PUT: api/Drons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDron(string id, Dron dron)
        {
            if (id != dron.NumeroSerie)
            {
                return BadRequest();
            }

            _context.Entry(dron).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DronExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Drons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dron>> PostDron(Dron dron)
        {
            Regex regexEstado = new Regex("^[A-Z- ]+$");
            if (dron.PesoLimite > 500)
            {
                return BadRequest("EL peso límite máximo es 500gr.");
            }

            if (dron.NumeroSerie.Length > 100)
            {
                return BadRequest("El numero de serie no puede ser mayor a 100 caracteres.");
            }
            if (!regexEstado.IsMatch(dron.Estado))
            {
                return BadRequest("El estado solo debe contener caracteres en mayusculas.");
            }

            _context.Drones.Add(dron);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DronExists(dron.NumeroSerie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDron", new { id = dron.NumeroSerie }, dron);
        }

        // DELETE: api/Drons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDron(string id)
        {
            var dron = await _context.Drones.FindAsync(id);
            if (dron == null)
            {
                return NotFound();
            }

            _context.Drones.Remove(dron);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DronExists(string id)
        {
            return _context.Drones.Any(e => e.NumeroSerie == id);
        }
    }
}
