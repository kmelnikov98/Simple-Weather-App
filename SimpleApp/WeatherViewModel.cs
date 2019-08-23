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


		public WeatherViewModel()
		{
			m_weatherDataFactory = new WeatherDataFactory();
		}

		#region Properties

		public IWeatherData WeatherData { get; set; }

		public string Latitude
		{
			get => WeatherData.GetLatitude();
		}

		public string Longitude
		{
			get => WeatherData.GetLongitude();
		}

		public string Weather
		{
			get => WeatherData.GetWeather();
		}

		public string MinTemperature
		{
			get => WeatherData.GetMinTemperature();
		}

		public string MaxTemperature
		{
			get => WeatherData.GetMaxTemperature();
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

		public ICommand SearchCommand => new RelayCommand(param => Search_()); //relay command supports normal actions, and canExecute. 

		//public ICommand newCommand => new Commands.Command(BurnToDisc_, CanBurnToDisc_);

		private void Search_()
		{
			if(WeatherData == null)
			{
				WeatherData = m_weatherDataFactory.Create();
			}

			UpdateValues_();
		}

		#endregion

		#region Private Methods

		private async void UpdateValues_()
		{
			if(m_city != null && m_city.Length > 0)
			{
				WeatherData.CityLocation = m_city;
			}

			if (m_country != null && m_country.Length > 0)
			{
				WeatherData.CountryLocation = m_country;
			}

			await WeatherData.GetWeatherDataAsync(); //update system

			OnPropertyChanged("Longitude");
			OnPropertyChanged("Latitude");
			OnPropertyChanged("Weather");
			OnPropertyChanged("MinTemperature");
			OnPropertyChanged("MaxTemperature");
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
