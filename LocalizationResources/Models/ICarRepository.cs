namespace LocalizationResources.Models
{
    public interface ICarRepository
    {
        List<Car> GetAllCars();
        Car GetCarById(int id);
        Car Create(Car car);
        void Update(Car car);
        void Delete(int id);
    }
}
