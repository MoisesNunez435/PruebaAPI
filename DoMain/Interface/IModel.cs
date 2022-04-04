using DoMain.Wheather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoMain.Interface
{
    public interface IModel
    {
        Root GetWeather(string Ciudad);
    }
}
