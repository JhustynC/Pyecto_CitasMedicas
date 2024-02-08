using Microsoft.AspNetCore.Mvc;
using WebAPIBasica.Application;
using WebAPIBasica.Models;

namespace WebAPIBasica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicDateController : Controller
    {
        private IMedicDateRepository _medicDateRepository;
        public MedicDateController(IMedicDateRepository medicDateRepository)
        {
            _medicDateRepository = medicDateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicDates()
        {
            return Ok(await _medicDateRepository.GetAllMedicDates());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicDate(int id)
        {
            return Ok(await _medicDateRepository.GetMedicDate(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicDate([FromBody] MedicDate md)
        {
            if (md == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _medicDateRepository.InsertMedicaDate(md);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] MedicDate md)
        {
            if (md == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _medicDateRepository.UpdateMedicaDate(md);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicDate(int id)
        {
            await _medicDateRepository.DeleteMedicaDate(new MedicDate { Id = id });

            return NoContent();
        }

    }
}
