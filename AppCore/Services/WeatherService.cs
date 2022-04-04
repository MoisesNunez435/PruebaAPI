using AppCore.Interface;
using DoMain.Interface;
using DoMain.Wheather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class WeatherService : IWeatherService
    {
        public IModel model;
        public WeatherService(IModel model)
        {
            this.model = model;
        }
        public Root GetWeather(string Ciudad)
        {
            return model.GetWeather(Ciudad);
        }
    }
}
