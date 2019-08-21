using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;

namespace SimpleApp
{
	class WeatherData : IWeatherData
	{


		private string m_weatherData;
		private const double k_tempZero = 273.15;

		#region Constructor

		public WeatherData() 
		{

		}

		#endregion

		#region IWeatherData Implementation

		public string CityLocation { get; set; }

		public string CountryLocation { get; set; }


		public string GetWeatherData()
		{
			if (CityLocation != null && CountryLocation != null)
			{
				HttpResponse<string> jsonResponse = Unirest.get("https://community-open-weather-map.p.rapidapi.com/weather?callback=test&id=2172797&units=%22metric%22+or+%22imperial%22&mode=xml%2C+html&q=" + CityLocation + "%2C+" + CountryLocation)
				.header("X-RapidAPI-Host", "community-open-weather-map.p.rapidapi.com")
				.header("X-RapidAPI-Key", "baa31766f0mshf8829a0c8da5dd9p1a932ajsn480bfe440f3b")
				.asJson<string>();

				m_weatherData = jsonResponse.Body;
			}

			return m_weatherData;
		}

		public string GetLatitude()
		{
			var data = m_weatherData;
			int pFrom = data.IndexOf("lat\":") + ("lat\":".Length); //gives starting position
			int pTo = data.IndexOf(",", pFrom); //give ending position of comma

			var result = data.Substring(pFrom, pTo - pFrom - 1); //-1 b/c you dont want the } value before the comma
			return result;
		}

		public string GetLongitude()
		{
			var data = m_weatherData;
			int pFrom = data.IndexOf("lon\":") + ("lon\":".Length); //gives starting position
			int pTo = data.IndexOf(",", pFrom); //give ending position of comma

			var result = data.Substring(pFrom, pTo - pFrom);

			return result;
		}

		public string GetWeather()
		{
			var data = m_weatherData;
			int pFrom = data.IndexOf("description\":") + ("description\":".Length); 
			int pTo = data.IndexOf(",", pFrom); 

			var result = data.Substring(pFrom, pTo - pFrom);

			return result;
		}

		public string GetMinTemperature()
		{
			var data = m_weatherData;

			int pFrom = data.IndexOf("temp_min\":") + ("temp_min\":".Length); 
			int pTo = data.IndexOf(",", pFrom); 

			var result = data.Substring(pFrom, pTo - pFrom);
			var tempInCelsius = (double.Parse(result) - k_tempZero).ToString() + "°C";

			return tempInCelsius;
		}

		public string GetMaxTemperature()
		{
			var data = m_weatherData;

			int pFrom = data.IndexOf("temp_max\":") + ("temp_max\":".Length); 
			int pTo = data.IndexOf(",", pFrom); 

			var result = data.Substring(pFrom, pTo - pFrom - 1);
			var tempInCelsius = (double.Parse(result) - k_tempZero).ToString() + "°C";

			return tempInCelsius;
		}

		#endregion

	}
}
