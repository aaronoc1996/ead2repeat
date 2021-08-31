using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ead2dbRepeat
{
                                                                             
    public class Forecast
    {
        public int ID { get; set; }                 // PK and identity
        public string city { get; set;}
        public string currentConditions { get; set; }            // null
        public int maxTemp { get; set; }
        public int minTemp { get; set; }
        public string wDirection { get; set; }
        public int wSpeed { get; set; }
        public string tomorrowForecast { get; set; }
        public override string ToString()
        {
            return ID + " " + city + " " + currentConditions + " " + maxTemp + " " + minTemp + "" + wDirection +  + wSpeed  + tomorrowForecast;
        }
    }

    // connection to db
    public class ForecastContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:ead2repeat.database.windows.net,1433;Initial Catalog=aocforecast;Persist Security Info=False;User ID=dbadmin;Password={Repeatca21};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;S")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        public DbSet<Forecast> Forecasts { get; set; }
    }

    static class Program
    {
        static void Add()
        {
            using ForecastContext db = new ForecastContext();

            // add 2 city forecasts
            Forecast f1 = new Forecast() { city = "Madrid", currentConditions = "Sunny", maxTemp = 32, minTemp =25, wDirection = "northeast", wSpeed=7, tomorrowForecast="Sunny" };
            Forecast f2 = new Forecast() { city = "kildare", currentConditions = "Sunny", maxTemp = 24, minTemp = 11, wDirection = "southheast", wSpeed = 3, tomorrowForecast = "Sunny" };

            db.Forecasts.Add(f1);
            db.Forecasts.Add(f2);
            db.SaveChanges();
        }



        static void QueryAll()
        {
            using ForecastContext db = new ForecastContext();

            // LINQ to entities
            var query = db.Forecasts.OrderBy(forecast=> forecast.city);
            foreach (var forecast in query)
            {
                Console.WriteLine(forecast);
            }

        }

        // update one cities current condition
        static void Update()
        {
            using ForecastContext db = new ForecastContext();

            var forecast = db.Forecasts.FirstOrDefault(f => f.city == "Cloudy");
            if (forecast != null)
            {
                forecast.currentConditions="Cloudy";
                db.SaveChanges();
            }
        }

        // delete a student
        static void Delete()
        {
            using ForecastContext db = new ForecastContext();

            // find Madrid
            var forecast = db.Forecasts.FirstOrDefault(f => f.city == "Madrid");
            if (forecast != null)
            {
                db.Forecasts.Remove(forecast);                  // delete entity
                db.SaveChanges();
            }
        }

        static void Main()
        {
            Add();
            Update();
            Delete();
            QueryAll();
        }
    }
}
