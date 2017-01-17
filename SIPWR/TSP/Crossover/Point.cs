using SIPWR.TSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                if (index < parentA.resultVector.length / 2)
                    newVector[index] = parentA.resultVector[index];
                else
                    newVector[index] = parentB.resultVector[index];

                index++;
            }
            return new Result(newVector, 0, 0);
        }
    }
}