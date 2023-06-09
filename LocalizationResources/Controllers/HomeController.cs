using LocalizationResources.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocalizationResources.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepo;

        public HomeController(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }
        public IActionResult Index()
        {
            List<Car> cars = _carRepo.GetAllCars();
            return View(cars);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepo.Create(car);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var car = _carRepo.GetCarById(id);
                return RedirectToAction("Index", new { id = car.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var car = _carRepo.GetCarById(id);
            if (car != null)
            {
                return View(car);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(Car car)
        {
            if (!ModelState.IsValid)
            {
              _carRepo.Update(car);
                return View(car);
            }
            else
            {
                return View();
            }
        }
    }
}
