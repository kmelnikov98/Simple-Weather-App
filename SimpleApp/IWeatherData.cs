﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
	public interface IWeatherData: IDisposable
	{
		string GetWeatherData();
		string GetLatitude();
		string GetLongitude();
	}
}
