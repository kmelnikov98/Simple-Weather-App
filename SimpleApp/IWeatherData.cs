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
		string GetWeatherData();
		string GetLatitude();
		string GetLongitude();
		string GetWeather();

	}
}
