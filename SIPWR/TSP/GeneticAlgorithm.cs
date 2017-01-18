using SIPWR.TSP.Crossover;
using SIPWR.TSP.Model;
using SIPWR.TSP.Mutator;
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
        public int mutatorValue { get; set; }

        public Tour best { get; set; }

        private Dictionary<string, Dictionary<string, double>> distances;

        private int generationCount;
        private int populationSize;

        private ICrossover crossover;
        private ISelection selection;
        private IMutator mutator;

        private DateTime startTime;
        private DateTime endTime;

        private Dictionary<City, double> FitnessCity;
        private List<Tour> populations;

        public GeneticAlgorithm(
            double mutationProbability,
            double recombinationProbability,
            int termination,
            int mutatorValue,
            int generationCount,
            int populationSize,
            CrossoverType crossoverType,
            SelectionType selectionType,
            MutatorType mutatortype,
            List<City> cities)
        {
            this.distances = Distance.Calculate(TourManager.Cities);
            this.mutationProbability = 1.0 / (TourManager.Cities.Count * mutatorValue);
            this.recombinationProbability = recombinationProbability;
            this.termination = termination;
            this.generationCount = generationCount;
            this.populationSize = populationSize;

            this.crossover = CrossoverFactory.Get(crossoverType);
            this.selection = SelectionFactory.Get(selectionType);
            this.mutator = MutatorFactory.Get(mutatortype);

            TourManager.Cities = cities;
        }

        public void Execute()
        {
            startTime = DateTime.Now;

            for (var i = 0; i < populationSize; i++)
            {
                var tour = Tour.GetRandomTour();
            }

            endTime = DateTime.Now;
        }

        private void NextGeneration()
        {
            var newGeneration = new List<Tour>();

            for (var i = 0; i < populationSize; i += 2)
            {
                var selection1 = selection.Selection(populations, distances);
                var selection2 = selection.Selection(populations, distances);
                var aux = crossover.Crossover(selection1, selection2);
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