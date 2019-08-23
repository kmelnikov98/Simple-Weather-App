using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
	public interface IWeatherData
	{
		string CityLocation { get; set; }
		string CountryLocation { get; set; }
		Task<string> GetWeatherDataAsync();
		string GetLatitude();
		string GetLongitude();
		string GetWeather();
		string GetMinTemperature();
		string GetMaxTemperature();
	}
}
