using SIPWR.TSP.Model;
using System.Collections.Generic;

namespace SIPWR.TSP
{
    public static class TSPCreatorHelper
    {
        public static List<City> GenerateCity(int n)
        {
            var cities = new List<City>();

            for (var i = 0; i < n; i++)
            {
                var city = City.GenerateCiy();
                cities.Add(city);
            }

            return cities;
        }
    }
}