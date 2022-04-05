using AppCore.Interface;
using DoMain.Wheather;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenWeatherApi
{
    public partial class FrmWeather : Form
    {
        IWeatherService weatherService;

        public FrmWeather(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
            InitializeComponent();
        }

      
        private void FrmWeather_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Root root = weatherService.GetWeather(textBox1.Text);
                double temp = root.main.Temp - 273.15;
                double tempMax = root.main.Temp_Max - 273.15;
                double tempMin = root.main.Temp_Min - 273.15;
                pictureBox1.ImageLocation = "https://openweathermap.org/img/w/" + root.weather[0].Icon + ".png";
                lblCondition.Text = root.weather[0].Main;
                lblDetails.Text = root.weather[0].Description;
                lblCountry.Text = root.sys.Country;
                //lblHumedity.Text = root.main.Humedity.ToString();
                lblLat.Text = root.coord.lan.ToString();
                lblLon.Text = root.coord.lon.ToString();
                //lblPressure.Text = root.main.Preasure.ToString();
                lblSpeed.Text = root.wind.Speed.ToString();
                lblTemp.Text = temp.ToString("0,0") + "°C";
                lblTenpMax.Text = tempMax.ToString("0,0") + "°C";
                lblTempMin.Text = tempMin.ToString("0,0") + "°C";
                lblSunrise.Text = ConvertLongtoDate(root.sys.Sunrise).ToShortTimeString();
                lblSunset.Text = ConvertLongtoDate(root.sys.Sunset).ToShortTimeString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Ciudad No Encontrada");
            }

        }

        DateTime ConvertLongtoDate(long date)
        {
            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            time = time.AddSeconds(date).ToLocalTime();
            return time;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
