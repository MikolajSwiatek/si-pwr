using SIPWR.TSP.Model;
using System.Collections.Generic;

namespace SIPWR.TSP
{
    public static class Distance
    {
        public static Dictionary<string, Dictionary<string, double>> Calculate(
            List<City> cities)
        {
            var distances = new Dictionary<string, Dictionary<string, double>>();

            foreach (var city1 in cities)
            {
                distances[city1.Name] = new Dictionary<string, double>();
                foreach (var city2 in cities)
                {
                    var distance = city1.Proximity(city2);
                    distances[city1.Name][city2.Name] = distance;
                }
            }

            return distances;
        }
    }
}