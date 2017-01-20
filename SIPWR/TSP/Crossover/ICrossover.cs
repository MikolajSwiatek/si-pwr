using System;

namespace SIPWR.TSP.Crossover
{
    public interface ICrossover
    {
        Tour Crossover(Tour tour1, Tour tour2);
    }
}
