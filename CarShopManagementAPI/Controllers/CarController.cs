using CarShopManagementAPI.Models;
using CarShopManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarShopManagementAPI.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _repository.GetAllCarsAsync());
        }

        [HttpGet]
        [Route("GetCarById/{id}")]
        public async Task<IActionResult> GetCarById(Guid id)
        {
            Car car = await _repository.GetCarByIdAsync(id);

            if (car == null) return NotFound();

            return Ok(car);
        }

        [HttpPost]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            Car createdCar = await _repository.CreateCarAsync(car);
            return CreatedAtAction(nameof(CreateCar), new Car { Id = createdCar.Id }, createdCar);
        }

        [HttpPut]
        [Route("UpdateCar")]
        public async Task<IActionResult> UpdateCar(Car car)
        {
            Car updatedCar = await _repository.UpdateCarAsync(car);
            return Ok(updatedCar);
        }

        [HttpDelete]
        [Route("DeleteCar")]
        public async Task<IActionResult> DeleteCar(Car car)
        {
            await _repository.DeleteCarAsync(car);
            return NoContent();
        }
    }
}
