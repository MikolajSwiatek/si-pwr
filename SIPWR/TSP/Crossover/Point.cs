using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.TSP.Crossover
{
    public class Point : ICrossover
    {
        private readonly double _ratePerGene;
        private const double RatePerGeneDefault = 0.5;

        public Point()
        {
            _ratePerGene = RatePerGeneDefault;
        }

        public Point(double ratePerGene)
        {
            _ratePerGene = ratePerGene;
        }

        public Tour Crossover(Tour tour1, Tour tour2)
        {
            throw new NotImplementedException();
        }
    }
}