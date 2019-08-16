using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class WeatherView 
		: Window, IDisposable
	{
		private WeatherViewModel m_weatherViewModel;
		public WeatherView()
		{
			InitializeComponent();
			m_weatherViewModel = new WeatherViewModel();
			this.DataContext = m_weatherViewModel;
		}

		public void Dispose()
		{
			m_weatherViewModel.Dispose();
			m_weatherViewModel = null;
		}
	}
}
