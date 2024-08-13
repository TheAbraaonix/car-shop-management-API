using CarShopManagementAPI.Models;
using CarShopManagementAPI.Repositories;

namespace CarShopManagementAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            IEnumerable<Car> cars = await _repository.GetAllCarsAsync();
            return cars;
        }

        public async Task<Car> GetCarById(Guid id)
        {
            Car? car = await _repository.GetCarByIdAsync(id);

            if (car == null) return null;

            return car;
        }

        public async Task<Car> CreateCar(Car car)
        {
            if (car == null) return null;

            Car createdCar = await _repository.CreateCarAsync(car);
            return createdCar;
        }
 
        public async Task<Car> UpdateCar(Guid id, Car car)
        {
            Car? foundCar = await _repository.GetCarByIdAsync(id);

            if (foundCar == null) return null;
            
            Car updatedCar = await _repository.UpdateCarAsync(id, car);
            return updatedCar;
        }

        public async Task<Car> DeleteCar(Guid id)
        {
            Car? car = await _repository.GetCarByIdAsync(id);

            if (car == null) return null;

            Car deletedCar = await _repository.DeleteCarAsync(car);
            return deletedCar;
        }
    }
}
