using SIPWR.TSP.Model;
using System.Collections.Generic;
using System.Linq;

namespace SIPWR.TSP.Crossover
{
    public class Point : ICrossover
    {

        public Tour Crossover(Tour tour1, Tour tour2)
        {
            var index = 0;
            var cities = new List<City>();

            while (index < tour1.TourCities.Count)
            {
                if (index < tour1.TourCities.Count / 2)
                {
                    cities.Add(tour1.TourCities.ElementAt(index));
                }
                else
                {
                    cities.Add(tour2.TourCities.ElementAt(index));
                }

                index++;
            }

            return new Tour(cities);
        }
    }
}