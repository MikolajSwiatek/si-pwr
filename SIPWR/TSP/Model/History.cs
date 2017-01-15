using System;
using System.Collections.Generic;

namespace SIPWR.TSP.Model
{
    public class History
    {
        public List<City> Tour { get; private set; }

        public double Distance { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public History(List<City> tour,
            double distance,
            DateTime startTime,
            DateTime endTime)
        {
            this.Tour = tour;
            this.Distance = distance;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}