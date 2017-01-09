using SIPWR.TSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.TSP
{
    public class GeneticAlgorithm : IAlgorithm
    {
        public int populationSize { get; set; }
        public double mutationProbability { get; set; }
        public double recombinationProbability { get; set; }
        public int termination { get; set; }
        public int mutator { get; set; }

        public Tour Tour { get; set; }

        private Dictionary<string, Dictionary<string, double>> distances;

        private int uselessGenerations;
        private CrossingType crossingType;
        private SelectionType selectionType;

        public GeneticAlgorithm(
            int populationSize,
            double mutationProbability,
            double recombinationProbability,
            int termination,
            int mutator,
            CrossingType crossingType,
            SelectionType selectionType,
            List<City> cities)
        {
            TourManager.Cities = cities;
            this.distances = Distance.Calculate(TourManager.Cities);
            this.populationSize = populationSize;
            this.mutationProbability = 1.0 / (TourManager.Cities.Count * mutator);
            this.recombinationProbability = recombinationProbability;
            this.termination = termination;
            this.uselessGenerations = 0;
            this.crossingType = crossingType;
            this.selectionType = selectionType;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public History GetResult()
        {
            return new History(Tour.TourCities, Tour.Distance);
        }

        public void Initialization()
        {

        }

        public void Selection()
        {

        }

        public void Crossover()
        {

        }

        public void Mutate()
        {

        }

        public void Evaluate()
        {

        }
    }
}