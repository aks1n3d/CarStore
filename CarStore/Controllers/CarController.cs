using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarStore.Domain.ViewModels.Car;
using CarStore.Service.Interfaces;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarStore.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var response = _carService.GetCars();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetCars");
            }
            return View("Error", $"{response.Description}");
        }

        public IActionResult Compare() => PartialView();

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
                return PartialView();

            var response = await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel viewModel)
        {
            ModelState.Remove("Id");
            ModelState.Remove("DateCreate");
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(viewModel.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)viewModel.Avatar.Length);
                    }
                    await _carService.Create(viewModel, imageData);
                }
                else
                {
                    await _carService.Edit(viewModel.Id, viewModel);
                }
            }
            return RedirectToAction("GetCars");
        }


        [HttpGet]
        public async Task<ActionResult> GetCar(int id, bool isJson)
        {
            var response = await _carService.GetCar(id);
            if (isJson)
            {
                return Json(response.Data);
            }
            return PartialView("GetCar", response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> GetCar(string term)
        {
            var response = await _carService.GetCar(term);
            return Json(response.Data);
        }

        [HttpPost]
        public JsonResult GetTypes()
        {
            var types = _carService.GetTypes();
            return Json(types.Data);
        }
    }
}









//if (!HttpContext.User.Identity.IsAuthenticated)
//{
//    return RedirectToAction("Login", "Account");
//}

//var response = await _shoesRepository.GetAllAsync();

//var response1 = await _shoesRepository.GetByName("Adidas");
//var response2 = await _shoesRepository.Get(0);

//var shoes = new Shoes()
//{
//    Name = "Adidas",
//    Model = "Ultra",
//    Price = 1200,
//    Description = "Кроссовки для бега",
//    DateCreated = DateTime.Now,
//    Speed = 20
//};

//await _shoesRepository.Create(shoes);

//await _shoesRepository.Delete(shoes);
