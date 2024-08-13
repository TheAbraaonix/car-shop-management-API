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
    }
}
