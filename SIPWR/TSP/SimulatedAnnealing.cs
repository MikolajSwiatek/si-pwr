using SIPWR.TSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIPWR.TSP
{
    public class SimulatedAnnealing : IAlgorithm
    {
        private double temp;
        private double coolingRate;
        private Dictionary<string, Dictionary<string, double>> distances;
        private Tour best;
        private DateTime startTime;
        private DateTime endTime;

        public SimulatedAnnealing(
            double temp,
            double coolingRate,
            int n,
            List<City> cities)
        {
            this.temp = temp;
            this.coolingRate = coolingRate;

            TourManager.Cities = cities;
            distances = Distance.Calculate(TourManager.Cities);
        }

        public SimulatedAnnealing(
            double temp,
            double coolingRate,
            int n)
        {
            this.temp = temp;
            this.coolingRate = coolingRate;

            TourManager.Cities = TSPCreatorHelper.GenerateCity(n);
            distances = Distance.Calculate(TourManager.Cities);
        }

        public void Execute()
        {
            startTime = DateTime.Now;
            var currentSolution = Tour.GetRandomTour();

            best = new Tour(currentSolution.TourCities);
            var random = new Random();

            best.GetDistance(distances);

            while (temp > 1)
            {
                var newSolution = new Tour(currentSolution.TourCities);

                var tourPos1 = random.Next(0, newSolution.TourCities.Count());
                var tourPos2 = random.Next(0, newSolution.TourCities.Count());

                var city1 = newSolution.TourCities.ElementAt(tourPos1);
                var city2 = newSolution.TourCities.ElementAt(tourPos2);

                newSolution.SetCity(tourPos2, city1);
                newSolution.SetCity(tourPos1, city2);

                var currentEnergy = currentSolution.GetDistance(distances);
                var neighbourEnergy = newSolution.GetDistance(distances);

                if (AcceptanceProbability(
                    currentEnergy,
                    neighbourEnergy,
                    temp) > random.Next(0, 1))
                {
                    currentSolution = new Tour(newSolution.TourCities);
                }

                if (currentSolution.GetDistance(distances) < best.GetDistance(distances))
                {
                    best = new Tour(currentSolution.TourCities);
                    best.GetDistance(distances);
                }

                temp *= 1 - coolingRate;
            }

            endTime = DateTime.Now;
        }

        private static double AcceptanceProbability(
            double energy,
            double newEnergy,
            double temperature)
        {
            if (newEnergy < energy)
            {
                return 1.0;
            }

            return Math.Exp((energy - newEnergy) / temperature);
        }

        public History GetResult()
        {
            return new History(
                best.TourCities,
                best.GetDistance(distances),
                startTime,
                endTime);
        }
    }
}