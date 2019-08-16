using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleApp
{
	public class WeatherViewModel 
		: IDisposable, INotifyPropertyChanged
	{
		private readonly IWeatherDataFactory m_weatherDataFactory;
		private string m_country;
		private string m_city;
		private string m_longitude;
		private string m_latitude;


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
				if (m_latitude == null)
				{
					m_latitude = WeatherData.GetLatitude();
					return m_latitude;
				}
				else
				{
					return m_latitude;
				}
			}
			set
			{
				if (value != null)
				{
					m_latitude = value;
				}

				OnPropertyChanged("Longitude");
			}
		}

		public string Longitude
		{
			get
			{
				if(m_longitude == null)
				{
					m_longitude = WeatherData.GetLongitude();
					return m_longitude;
				}
				else
				{
					return m_longitude;
				}
			}
			set
			{
				if(value != null)
				{
					m_longitude = value;
				}

				OnPropertyChanged("Longitude");
			}
		}

		public string City
		{
			get { return m_city; }
			set { m_city = value; }
		}

		public string Country
		{
			get { return m_country; }
			set { m_country = value; }

		}

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region ICommand Implementation

		public ICommand SearchCommand => new RelayCommand(param => Search_());

		//public ICommand EzcCommand => new Commands.DelegateCommand(BurnToDisc_, CanBurnToDisc_);

		private void Search_()
		{
			UpdateValues_();
			OnPropertyChanged("Longitude");
			OnPropertyChanged("Latitude");

		}

		#endregion

		#region Private Methods

		private void UpdateValues_()
		{
			if(m_city != null && m_city.Length > 0)
			{
				WeatherData.CityLocation = m_city;
			}

			if (m_country != null && m_country.Length > 0)
			{
				WeatherData.CountryLocation = m_country;
			}

			WeatherData.GetWeatherData(); //update system
		}

		#endregion

		#region IDisposable Implementation

		public void Dispose()
		{
			WeatherData = null;
		}

		#endregion

		#region INotifyPropertyChanged Implementation

		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}

		#endregion
	}
}
