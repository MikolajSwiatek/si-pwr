using System.Collections.Generic;

namespace SIPWR.TSP.Model
{
    public class History
    {
        public List<City> Tour { get; private set; }
        public double Distance { get; private set; }

        public History(List<City> tour, double distance)
        {
            this.Tour = tour;
            this.Distance = distance;
        }
    }
}