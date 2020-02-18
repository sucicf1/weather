using System.Collections.Generic;

namespace weather.Models
{
    public class WeatherData
    {
        public class WeatherDisplayData
        {
            public string City { get; set; }
            public string Country { get; set; }
            public string Lat { get; set; }
            public string Lon { get; set; }
            public string Pressure { get; set; }
            public string Humidity { get; set; }
            public string TempCelsius { get; set; }
            public string TempFahrenheit { get; set; }
            public string TempFeelsLikeCelsius { get; set; }
            public string TempFeelsLikeFahrenheit { get; set; }
            public string TempMaxCelsius { get; set; }
            public string TempMaxFahrenheit { get; set; }
            public string TempMinCelsius { get; set; }
            public string TempMinFahrenheit { get; set; }
        }

        public class Coord
        {
            public double Lon { get; set; }
            public double Lat { get; set; }
        }

        public class Weather
        {
            public int Id { get; set; }
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }

        public class Main
        {
            public float Temp { get; set; }
            public float Feels_like { get; set; }
            public float Temp_min { get; set; }
            public float Temp_max { get; set; }
            public float Pressure { get; set; }
            public float Humidity { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
            public int Deg { get; set; }
        }

        public class Clouds
        {
            public int All { get; set; }
        }

        public class Sys
        {
            public int Type { get; set; }
            public int Id { get; set; }
            public string Country { get; set; }
            public int Sunrise { get; set; }
            public int Sunset { get; set; }
        }

        public class RootObject
        {
            public Coord Coord { get; set; }
            public List<Weather> Weather { get; set; }
            public string Base { get; set; }
            public Main Main { get; set; }
            public int Visibility { get; set; }
            public Wind Wind { get; set; }
            public Clouds Clouds { get; set; }
            public int Dt { get; set; }
            public Sys Sys { get; set; }
            public int Timezone { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Cod { get; set; }
        }
    }
}