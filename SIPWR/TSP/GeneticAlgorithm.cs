﻿using SIPWR.TSP.Crossover;
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
        public int mutatorValue { get; set; }

        private Dictionary<string, Dictionary<string, double>> distances;

        private int generationCount;
        private int populationSize;

        private ICrossover crossover;
        private ISelection selection;

        private DateTime startTime;
        private DateTime endTime;

        private List<Tour> populations = new List<Tour>();
        private Tour best = null;

        public GeneticAlgorithm(
            int mutatorValue,
            int generationCount,
            int populationSize,
            CrossoverType crossoverType,
            SelectionType selectionType,
            List<City> cities)
        {
            this.mutationProbability = 1.0 / (TourManager.Cities.Count * mutatorValue);
            this.generationCount = generationCount;
            this.populationSize = populationSize;

            this.crossover = CrossoverFactory.Get(crossoverType);
            this.selection = SelectionFactory.Get(selectionType);

            TourManager.Cities = cities;
            this.distances = Distance.Calculate(TourManager.Cities);
        }

        public void Execute()
        {
            startTime = DateTime.Now;
            GeneratePopulations();

            for (var i = 0; i < generationCount; i++)
            {
                NextGeneration();
            }

            endTime = DateTime.Now;
        }

        private void GeneratePopulations()
        {
            for (var i = 0; i < populationSize; i++)
            {
                var tour = Tour.GetRandomTour();
                populations.Add(tour);
            }
        }

        private void NextGeneration()
        {
            var newGeneration = new List<Tour>();

            for (var i = 0; i < populationSize; i += 2)
            {
                var selection1 = selection.Selection(populations, distances);
                var selection2 = selection.Selection(populations, distances);
                var aux = crossover.Crossover(selection1, selection2);

                Mutation(aux);

                aux.GetDistance(distances);
                newGeneration.Add(aux);
            }

            SetBest(newGeneration);
        }

        private void Mutation(Tour aux)
        {
            for (var index = 0; index < aux.TourCities.Count(); index++)
            {
                if (RandomHelper.Random.NextDouble() < mutationProbability)
                {
                    var city1 = aux.TourCities[index];
                    City city2 = null;

                    if (index + 1 < aux.TourCities.Count())
                    {
                        city2 = aux.TourCities[index + 1];
                        aux.TourCities[index + 1] = city1;
                    }
                    else
                    {
                        city2 = aux.TourCities[0];
                        aux.TourCities[0] = city1;
                    }

                    aux.TourCities[index] = city2;
                }
            }
        }

        private void SetBest(List<Tour> newGeneration)
        {
            foreach (var ng in newGeneration)
            {
                ng.GetDistance(distances);

                var ngCitiesCount = TourManager.Cities
                    .Where(c => ng.TourCities.Contains(c))
                    .Count();

                if (best == null || (best.Fitness < ng.Fitness &&
                    ngCitiesCount == TourManager.Cities.Count()))
                {
                    best = ng;
                }
            }
        }

        public History GetResult()
        {
            return new History(best.TourCities,
                best.GetDistance(distances),
                startTime,
                endTime);
        }
    }
}