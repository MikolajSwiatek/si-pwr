using SIPWR.TSP.Model;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SIPWR.TSP.Crossover
{
    public class Uniform : ICrossover
    {
        private readonly double _ratePerGene;
        private const double RatePerGeneDefault = 0.5;

        public Uniform()
        {
            _ratePerGene = RatePerGeneDefault;
        }

        public Uniform(double ratePerGene)
        {
            _ratePerGene = ratePerGene;
        }

        public Tour Crossover(Tour tour1, Tour tour2)
        {
            var cities = new List<City>();

            for (var index=0; index<tour1.TourCities.Count; index++)
            {
                if (RandomHelper.Random.NextDouble() < _ratePerGene)
                {
                    if (!cities.Contains(tour1.TourCities.ElementAt(index)))
                    {
                        cities.Add(tour1.TourCities.ElementAt(index));
                    }
                }
                else
                {
                    if (!cities.Contains(tour2.TourCities.ElementAt(index)))
                    {
                        cities.Add(tour2.TourCities.ElementAt(index));
                    }
                }
            }

            var citiesNotExistInresult = tour1.TourCities.Where(tc => cities.Contains(tc) == false);
            cities.AddRange(citiesNotExistInresult);

            return new Tour(cities);
        }
    }
}