using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
	public class WeatherViewModel: IDisposable
	{
		private readonly IWeatherDataFactory m_weatherDataFactory;

		public WeatherViewModel()
		{
			m_weatherDataFactory = new WeatherDataFactory();
			m_weatherDataFactory.Create();
		}

		public IWeatherData WeatherData { get; set; }

		public void Dispose()
		{
			WeatherData = null;
		}
	}
}
