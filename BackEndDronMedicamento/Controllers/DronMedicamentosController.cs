using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndDronMedicamento;
using BackEndDronMedicamento.Entidades;

namespace BackEndDronMedicamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronMedicamentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DronMedicamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DronMedicamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DronMedicamento>>> GetDronMedicamentos()
        {
            return await _context.DronMedicamentos.ToListAsync();
        }

        // GET: api/DronMedicamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DronMedicamento>> GetDronMedicamento(string id)
        {
            var dronMedicamento = await _context.DronMedicamentos.FindAsync(id);

            if (dronMedicamento == null)
            {
                return NotFound();
            }

            return dronMedicamento;
        }

        //// PUT: api/DronMedicamentos/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDronMedicamento(string id, DronMedicamento dronMedicamento)
        //{
        //    if (id != dronMedicamento.CodigoDron)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(dronMedicamento).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DronMedicamentoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/DronMedicamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DronMedicamento>> PostDronMedicamento(DronMedicamento dronMedicamento)
        {
            var dron = await _context.Drones.FirstOrDefaultAsync(dron => dron.NumeroSerie == dronMedicamento.CodigoDron);
            if (dron == null)
                return BadRequest("El dron buscado no existe");

            if(dron.CapacidadBateria < 25)
                return BadRequest("la batería del Dron está por debajo del 25%");

            var medicamento = await _context.Medicamentos.FirstOrDefaultAsync(med => med.Codigo == dronMedicamento.CodigoMedicamento);
            if (medicamento == null)
                return BadRequest("El medicamento buscado no existe");

            if(dron.Estado == "INACTIVO" ||
                dron.Estado == "CARGADO" ||
                dron.Estado == "ENTREGANDO CARGA")
                return BadRequest("El estado del Dron impide su utilización.");

            //Listado de medicamentos en la carga del drom
            var medicamentosDronList = await _context.DronMedicamentos.Where(dm => dm.CodigoDron == dronMedicamento.CodigoMedicamento
                && dm.CodigoDron == dron.NumeroSerie).ToListAsync();
            
            var totalPeso = 0;
            foreach (DronMedicamento dm in medicamentosDronList)
            {
                var medUtilizado = await _context.Medicamentos.FirstOrDefaultAsync(m => m.Codigo == dm.CodigoMedicamento);
                if (medUtilizado != null)
                    totalPeso += medUtilizado.Peso;
            }


            if (totalPeso > 500)
                return BadRequest("Se ha sebrepasado el peso máximo del Dron: 500gr");


            _context.DronMedicamentos.Add(dronMedicamento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DronMedicamentoExists(dronMedicamento.CodigoDron))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDronMedicamento", new { id = dronMedicamento.CodigoDron }, dronMedicamento);
        }

        // DELETE: api/DronMedicamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDronMedicamento(string id)
        {
            var dronMedicamento = await _context.DronMedicamentos.FindAsync(id);
            if (dronMedicamento == null)
            {
                return NotFound();
            }

            _context.DronMedicamentos.Remove(dronMedicamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DronMedicamentoExists(string id)
        {
            return _context.DronMedicamentos.Any(e => e.CodigoDron == id);
        }
    }
}
