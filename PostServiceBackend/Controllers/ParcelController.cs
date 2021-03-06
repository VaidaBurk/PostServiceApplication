using Microsoft.AspNetCore.Mvc;
using PostServiceBackend.Dtos;
using PostServiceBackend.Services;
using System;
using System.Threading.Tasks;

namespace PostServiceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelController : Controller
    {
        private readonly ParcelService _parcelService;

        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _parcelService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _parcelService.GetByIdAsync(id));
            }
            catch (ArgumentException exception)
            {
                return StatusCode(404, exception.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(ParcelAddDto newParcel)
        {
            try
            {
                return Ok(await _parcelService.AddAsync(newParcel));
            }
            catch (ArgumentException exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ParcelUpdateDto updatedParcel)
        {
            try
            {
                return Ok(await _parcelService.UpdateAsync(id, updatedParcel));
            }
            catch (ArgumentException exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _parcelService.RemoveAsync(id);
                return NoContent();
            }
            catch (ArgumentException exception)
            {
                return StatusCode(404, exception.Message);
            }
        }

        [HttpGet("ParcelMachine/{id}")]
        public async Task<ActionResult> GetFilteredByParcelMachineId(int id)
        {
            return Ok(await _parcelService.GetFilteredByParcelMachineId(id));
        }
    }
}
