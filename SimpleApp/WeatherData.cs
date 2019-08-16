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
		#region IWeatherData Implementation

		private string m_weatherData;

		public WeatherData()
		{
			GetWeatherData();
		}

		public string GetWeatherData()
		{
			HttpResponse<string> jsonResponse = Unirest.get("https://community-open-weather-map.p.rapidapi.com/weather?callback=test&id=2172797&units=%22metric%22+or+%22imperial%22&mode=xml%2C+html&q=port+coquitlam%2C+canada")
			.header("X-RapidAPI-Host", "community-open-weather-map.p.rapidapi.com")
			.header("X-RapidAPI-Key", "baa31766f0mshf8829a0c8da5dd9p1a932ajsn480bfe440f3b")
			.asJson<string>();

			m_weatherData = jsonResponse.Body;

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

		#endregion


	}
}
