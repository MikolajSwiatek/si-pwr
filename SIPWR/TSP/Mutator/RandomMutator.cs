using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.TSP.Mutator
{
    public class RandomMutator : IMutator
    {
        public void Mutate(Tour tour, double mutationProbability)
        {
            if (RandomHelper.Random.NextDouble() < mutationProbability)
            {
                var value = RandomHelper.Random.Next(tour.TourCities.Count);
                // TODO
            }
        }
    }
}