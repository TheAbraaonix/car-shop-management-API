using CarShopManagementAPI.Models;

namespace CarShopManagementAPI.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarById(Guid id);
        Task<Car> CreateCar(Car car);
        Task<Car> UpdateCar(Guid id, Car car);
        Task<Car> DeleteCar(Guid id);
    }
}
