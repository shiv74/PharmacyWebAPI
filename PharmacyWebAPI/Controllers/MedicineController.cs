using Microsoft.AspNetCore.Mvc;
using PharmacyWebAPI.Data;
using PharmacyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWebAPI.Controllers
{
    [Route("/api/[Controller]")]
    public class MedicineController : Controller
    {
        private readonly PharmacyDBContext _context;
        public MedicineController(PharmacyDBContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<Medicine> GetAll()
        {
            return _context.Medicine.ToList();
        }

        [HttpPost]
        public IActionResult AddMedicine([FromBody] Medicine medicine)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid inputs");

            medicine.medicineId = Guid.NewGuid().ToString();
            _context.Medicine.Add(medicine);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(string id)
        {
            var medicine = await _context.Medicine.FindAsync(id);
            if(medicine == null)
            {
                return NotFound();
            }

            _context.Medicine.Remove(medicine);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
