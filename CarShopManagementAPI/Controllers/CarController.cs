using CarShopManagementAPI.Models;
using CarShopManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarShopManagementAPI.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _service.GetAllCars());
        }

        [HttpGet]
        [Route("GetCarById/{id}")]
        public async Task<IActionResult> GetCarById(Guid id)
        {
            Car car = await _service.GetCarById(id);

            if (car == null) return NotFound($"The car with the id {id} does not exist.");

            return Ok(car);
        }

        [HttpPost]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            Car createdCar = await _service.CreateCar(car);
            return CreatedAtAction(nameof(CreateCar), new Car { Id = createdCar.Id }, createdCar);
        }

        [HttpPut]
        [Route("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, Car car)
        {
            Car updatedCar = await _service.UpdateCar(id, car);

            if (updatedCar == null) return BadRequest($"The car with the id {id} does not exist.");

            return Ok(updatedCar);
        }

        [HttpDelete]
        [Route("DeleteCar/{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            Car deletedCar = await _service.DeleteCar(id);

            if (deletedCar == null) return BadRequest($"The car with the id {id} does not exist.");

            return NoContent();
        }
    }
}
