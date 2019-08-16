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
			WeatherData = m_weatherDataFactory.Create();
		}

		#region Properties

		public IWeatherData WeatherData { get; set; }

		public string Latitude
		{
			get
			{
				return WeatherData.GetLatitude();
			}
		}

		public string Longitude
		{
			get
			{
				return WeatherData.GetLongitude();
			}
		}

		#endregion

		#region IDisposable Implementation

		public void Dispose()
		{
			WeatherData = null;
		}

		#endregion
	}
}
