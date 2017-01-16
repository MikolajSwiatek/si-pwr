using SIPWR.TSP.Crossover;
using SIPWR.TSP.Model;
using SIPWR.TSP.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.TSP
{
    public class GeneticAlgorithm : IAlgorithm
    {
        public double mutationProbability { get; set; }
        public double recombinationProbability { get; set; }
        public int termination { get; set; }
        public int mutator { get; set; }

        public Tour best { get; set; }

        private Dictionary<string, Dictionary<string, double>> distances;

        private int generationCount;
        private int populationSize;

        private ICrossover crossover;
        private ISelection selection;

        private DateTime startTime;
        private DateTime endTime;

        private Dictionary<City, double> FitnessCity;
        private List<Tour> populations;

        public GeneticAlgorithm(
            double mutationProbability,
            double recombinationProbability,
            int termination,
            int mutator,
            int generationCount,
            int populationSize,
            CrossoverType crossoverType,
            SelectionType selectionType,
            List<City> cities)
        {
            this.distances = Distance.Calculate(TourManager.Cities);
            this.mutationProbability = 1.0 / (TourManager.Cities.Count * mutator);
            this.recombinationProbability = recombinationProbability;
            this.termination = termination;
            this.generationCount = generationCount;
            this.populationSize = populationSize;

            this.crossover = CrossoverFactory.Get(crossoverType);
            this.selection = SelectionFactory.Get(selectionType);
            TourManager.Cities = cities;
        }

        public void Execute()
        {
            startTime = DateTime.Now;

            for (var i = 0; i < populationSize; i++)
            {
                var tour = new Tour();
                tour.GenerateIndividual();
                populations.Add(tour);
            }

            endTime = DateTime.Now;
        }

        private void NextGeneration()
        {
            var newGeneration = new List<Tour>();

            for (var i = 0; i < populationSize; i += 2)
            {
            }
        }

        public History GetResult()
        {
            return new History(best.TourCities,
                best.GetDistance(distances),
                startTime,
                endTime);
        }

        private Tour Selection(Tour currentPopulation, Tour newPopulation)
        {
            throw new NotImplementedException();
        }

        private void Crossover()
        {

        }

        private void Mutate()
        {

        }

        private void Evaluate()
        {

        }
    }
}