using System.Collections.Generic;

namespace SIPWR.TSP.Selection
{
    public class Tournament : ISelection
    {
        public Tour Selection(
            List<Tour> populations,
            Dictionary<string, Dictionary<string, double>> distances)
        {
            var index1 = RandomHelper.Random.Next(0, populations.Count);
            var index2 = RandomHelper.Random.Next(0, populations.Count);

            populations[index1].GetDistance(distances);
            populations[index2].GetDistance(distances);

            if (PopulationCompareTo(populations[index1], populations[index2]) < 0)
            {
                return populations[index2];
            }

            return populations[index1];
        }

        private int PopulationCompareTo(Tour population1, Tour population2)
        {
            if (population1.Fitness < population2.Fitness)
            {
                return -1;
            }
            else if (population1.Fitness > population2.Fitness)
            {
                return 1;
            }

            return 0;
        }
    }
}