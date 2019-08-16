using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
	public class WeatherDataFactory: IWeatherDataFactory
	{
		public IWeatherData Create()
		{
			return new WeatherData();
		}
	}
}
