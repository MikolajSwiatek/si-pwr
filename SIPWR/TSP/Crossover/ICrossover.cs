using System;

namespace SIPWR.TSP.Crossover
{
    interface ICrossover
    {
        Tour Crossover(Tour tour1, Tour tour2);
    }
}
