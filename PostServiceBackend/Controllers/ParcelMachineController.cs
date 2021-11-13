using Microsoft.AspNetCore.Mvc;
using PostServiceBackend.Dtos;
using PostServiceBackend.Services;
using System;
using System.Threading.Tasks;

namespace PostServiceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelMachineController : Controller
    {
        private readonly ParcelMachineService _parcelMachineService;

        public ParcelMachineController(ParcelMachineService parcelMachineService)
        {
            _parcelMachineService = parcelMachineService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _parcelMachineService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _parcelMachineService.GetByIdAsync(id));
            }
            catch (ArgumentException exception)
            {
                return StatusCode(404, exception.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(ParcelMachineAddDto newParcelMachine)
        {
            return Ok(await _parcelMachineService.AddAsync(newParcelMachine));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ParcelMachineUpdateDto updatedParcelMachine)
        {
            try
            {
                await _parcelMachineService.UpdateAsync(id, updatedParcelMachine);
                return NoContent();
            }
            catch (ArgumentException exception)
            {
                return StatusCode(404, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _parcelMachineService.RemoveAsync(id);
                return NoContent();
            }
            catch (ArgumentException exception)
            {
                return StatusCode(404, exception.Message);
            }
        }
    }
}
