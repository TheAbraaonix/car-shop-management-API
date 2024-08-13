using CarShopManagementAPI.Models;

namespace CarShopManagementAPI.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(Guid id);
        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task<Car> DeleteCarAsync(Car car);
    }
}
