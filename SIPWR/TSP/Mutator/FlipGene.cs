using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.TSP.Mutator
{
    public class FlipGene : IMutator
    {
        public void Mutate(Tour tour, double mutationProbability)
        {
            for (var index = 0; index < tour.TourCities.Count; index++)
            {
                // TODO
            }
        }
    }
}