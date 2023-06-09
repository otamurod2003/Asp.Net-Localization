using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
namespace LocalizationResources.Models
{
    public class CarRepository : ICarRepository
    {
        string? connectionString;
        public Car Create(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Cars(CarName,Price) VALUES(@CarName,@Price)";
                db.Execute(sqlQuery, car);
                return car;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //var car = "SELECT * FROM Cars WHERE Id";
                var sqlQuery = "DELETE FROM Cars WHERE Id=@Id";
                db.Query(sqlQuery, new { id });
            }
        }

        public List<Car> GetAllCars()
        {
          List<Car> cars = new List<Car>();
            using(IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Cars";
                cars = db.Query<Car>(sqlQuery).ToList();
            }
            return cars;
        }

        public Car GetCarById(int id)
        {
            Car? car = null;
            using(IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Cars WHERE Id=@Id";
                car = db.Query<Car>(sqlQuery, new { id }).FirstOrDefault();
            }
            return car;
        }

       public void Update(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var query = "UPDATE Cars SET CarName=@CarName, Price=@Price WHERE Id=@Id";
                db.Execute(query, car);
            }           
        }     
    }
}
