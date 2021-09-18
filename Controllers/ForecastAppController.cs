using ForecastApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiInMVC.Models;
using WebApiInMVC.OpenWeatherMapModels;

namespace WebApiInMVC.Controllers
{
    public class ForecastAppController : Controller
    {
        private readonly IForecastRepository _forecastRepository;
        public ForecastAppController(IForecastRepository forecastAppRepo)
        {
            _forecastRepository = forecastAppRepo;
        }
        public IActionResult SearchCity()
        {
            try
            {
                var viewmodel = new SearchCity();
                return View(viewmodel);
            }
            catch (Exception)
            {
                return StatusCode(500, "Bad Request");
            }
            
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City" , "ForecastApp" , new { city = model.CityName});
            }

            return View(model);
        }

        public IActionResult City(string City)
        {
            WeatherResponse weatherresponse = _forecastRepository.GetForecast(City);
            City viewmodel = new City();

            if (weatherresponse != null)
            {
                viewmodel.Name = weatherresponse.Name;
                viewmodel.Humidity = weatherresponse.Main.Humidity;
                viewmodel.Pressure = weatherresponse.Main.Pressure;
                viewmodel.Temp = weatherresponse.Main.Temp;
                viewmodel.Weather = weatherresponse.Weather[0].Main;
                viewmodel.Wind = weatherresponse.Wind.Speed;
            }
            return View(viewmodel);
        }
    }
}
