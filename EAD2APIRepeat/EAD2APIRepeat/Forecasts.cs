using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EAD2APIRepeat
{
    public class Forecasts
    {
        [Required]
        public int ID { get; set; }                 //  identity
        public string city { get; set; }
        public string currentConditions { get; set; }            
        public int maxTemp { get; set; }
        public int minTemp { get; set; }
        public string wDirection { get; set; }
        public int wSpeed { get; set; }
        public string tomorrowForecast { get; set; }
    }
}
