using SIPWR.TSP.Model;
using System.Collections.Generic;
using System.Linq;

namespace SIPWR.TSP.Crossover
{
    public class TwoPoint : ICrossover
    {
        public Tour Crossover(Tour tour1, Tour tour2)
        {
            var cities = new List<City>();
            var count = tour1.TourCities.Count;

            var firstSwapPoint = RandomHelper.Random.Next(1, (int)(count / 2 - 1));
            var secondSwapPoint = RandomHelper.Random.Next(1, (int)(count / 2 + 1));

            for (var index = 0; index < count; index++)
            {
                if (index < firstSwapPoint)
                {
                    cities.Add(tour1.TourCities.ElementAt(index));

                }
                else if (index < secondSwapPoint)
                {
                    cities.Add(tour2.TourCities.ElementAt(index));

                }
                else
                {
                    cities.Add(tour1.TourCities.ElementAt(index));

                }
            }

            return new Tour(cities);
        }
    }
}