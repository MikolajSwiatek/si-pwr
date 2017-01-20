using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.TSP.Selection
{
    public class Roulette : ISelection
    {
        public Roulette()
        {

        }

        public Tour Selection(
            List<Tour> populations,
            Dictionary<string, Dictionary<string, double>> distances)
        {
            var tournament = RandomHelper.Random.NextDouble();
            double aux = 0;
            double sum = 0;

            for (var i = 0; i < populations.Count; i++)
            {
                populations[i].GetDistance(distances);
                sum += populations[i].Fitness;
            }

            for (var i = 0; i < populations.Count; i++)
            {
                aux += populations[i].Fitness / sum;

                if (tournament <= aux)
                {
                    return populations[i];
                }
            }

            return null;
        }
    }
}