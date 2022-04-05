using AppCore.Interface;
using AppCore.Services;
using Autofac;
using DoMain.Interface;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenWeatherApi
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonWeatherRepository>().As<IModel>();
            builder.RegisterType<WeatherService>().As<IWeatherService>();
            var container = builder.Build();
            Application.Run(new FrmWeather(container.Resolve<IWeatherService>()));
        }
    }
}
