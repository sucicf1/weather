using System;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static weather.Models.WeatherData;

namespace weather.Controllers
{
    public class HomeController : Controller
    {
        public WeatherDisplayData GetCityWeatherData(string City)
        {
            string appId = "";
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&appid={1}", City, appId);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);
                WeatherDisplayData result = new WeatherDisplayData();
                result.Country = weatherInfo.Sys.Country;
                result.City = weatherInfo.Name;
                result.Lat = Convert.ToString(weatherInfo.Coord.Lat);
                result.Lon = Convert.ToString(weatherInfo.Coord.Lon);
                result.Pressure = Convert.ToString(weatherInfo.Main.Pressure);
                result.Humidity = Convert.ToString(weatherInfo.Main.Humidity);
                result.TempCelsius = Convert.ToString(weatherInfo.Main.Temp);
                result.TempFahrenheit = Convert.ToString(weatherInfo.Main.Temp * 9 / 5.0 + 32);
                result.TempFeelsLikeCelsius = Convert.ToString(weatherInfo.Main.Feels_like);
                result.TempFeelsLikeFahrenheit = Convert.ToString(weatherInfo.Main.Feels_like * 9 / 5.0 + 32);
                result.TempMaxCelsius = Convert.ToString(weatherInfo.Main.Temp_max);
                result.TempMaxFahrenheit = Convert.ToString(weatherInfo.Main.Temp_max * 9 / 5.0 + 32);
                result.TempMinCelsius = Convert.ToString(weatherInfo.Main.Temp_min);
                result.TempMinFahrenheit = Convert.ToString(weatherInfo.Main.Temp_min * 9 / 5.0 + 32);
                return result;
            }
        }
        public ActionResult Index(string City = "Sveta Nedelja")
        {
            WeatherDisplayData weatherInfo = GetCityWeatherData(City);

            ViewBag.Country = weatherInfo.Country;
            ViewBag.City = weatherInfo.City;
            ViewBag.Lat = Convert.ToString(weatherInfo.Lat);
            ViewBag.Lon = Convert.ToString(weatherInfo.Lon);
            ViewBag.Pressure = Convert.ToString(weatherInfo.Pressure);
            ViewBag.Humidity = Convert.ToString(weatherInfo.Humidity);
            ViewBag.TempCelsius = Convert.ToString(weatherInfo.TempCelsius);
            ViewBag.TempFahrenheit = Convert.ToString(weatherInfo.TempFahrenheit);
            ViewBag.TempFeelsLikeCelsius = Convert.ToString(weatherInfo.TempFeelsLikeCelsius);
            ViewBag.TempFeelsLikeFahrenheit = Convert.ToString(weatherInfo.TempFeelsLikeFahrenheit);
            ViewBag.TempMaxCelsius = Convert.ToString(weatherInfo.TempMaxCelsius);
            ViewBag.TempMaxFahrenheit = Convert.ToString(weatherInfo.TempMaxFahrenheit);
            ViewBag.TempMinCelsius = Convert.ToString(weatherInfo.TempMinCelsius);
            ViewBag.TempMinFahrenheit = Convert.ToString(weatherInfo.TempMinFahrenheit);

            return View();
        }

        public ActionResult Download()
        {
            WeatherDisplayData svetaNedeljaData = GetCityWeatherData("Sveta Nedelja");
            WeatherDisplayData splitData = GetCityWeatherData("Split");
            WeatherDisplayData osijekData = GetCityWeatherData("Osijek");
            string filePath = Server.MapPath("~/weatherData.txt");
            FileInfo allDataFile = new FileInfo(filePath);
            if (allDataFile.Exists) allDataFile.Delete();

            using (StreamWriter w = allDataFile.CreateText())
            {
                w.WriteLine(new JavaScriptSerializer().Serialize(svetaNedeljaData));
                w.WriteLine(new JavaScriptSerializer().Serialize(splitData));
                w.WriteLine(new JavaScriptSerializer().Serialize(osijekData));
            }
            
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filePath,
                Inline = false,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(allDataFile.OpenRead(), "text/plain");
        }
    }
}