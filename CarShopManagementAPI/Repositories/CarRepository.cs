using CarShopManagementAPI.Context;
using CarShopManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShopManagementAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            IEnumerable<Car> cars = await _context.Cars.ToListAsync();
            return cars;
        }

        public async Task<Car> GetCarByIdAsync(Guid id)
        {
            Car? car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            return car;
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCarAsync(Car car)
        {
            _context.Set<Car>().Update(car);
            await _context.SaveChangesAsync();
            return car;

        }

        public async Task<Car> DeleteCarAsync(Car car)
        {
            _context.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
