using SIPWR.Data;
using SIPWR.Models;
using SIPWR.TSP;
using SIPWR.TSP.Crossover;
using SIPWR.TSP.Model;
using SIPWR.TSP.Selection;
using SIPWR.ViewServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIPWR.Areas.Problems.Controllers
{
    public class TSPController : Controller
    {
        public ActionResult Index()
        {
            var enumService = new EnumService();

            var model = new TSPViewModel();
            model.CrossoverTypes = enumService.GetCrossoverTypes();
            model.TSPAlgorithms = enumService.GetTSPAlgorithmTypes();
            model.SelectionTypes = enumService.GetSelectionTypes();

            model.Temperature = 1000;
            model.Number = 20;
            model.CoolingRate = 0.003;

            model.MutatorValue = 2;
            model.GenerationCount = 100;
            model.PopulationSize = 300;

            return View(model);
        }

        public ActionResult Result(TSPViewModel model)
        {
            var algorithmType = (TSPAlgorithm)Enum.Parse(
                typeof(TSPAlgorithm),
                model.SelectedPosition);

            var crossoverType = (CrossoverType)Enum.Parse(
                typeof(CrossoverType),
                model.SelectedCrossoverPosition);

            var selectionType = (SelectionType)Enum.Parse(
                typeof(SelectionType),
                model.SelectedSelectionPosition);

            IAlgorithm algorithm = null;
            List<City> cities;

            if (!string.IsNullOrEmpty(model.Cities))
            {
                cities = new List<City>();
                foreach (var line in model.Cities.Split('\n'))
                {
                    var words = line.Split(';');

                    var city = new City()
                    {
                        Name = words[0],
                        X = double.Parse(words[1]),
                        Y = double.Parse(words[2])
                    };

                    cities.Add(city);
                }
            }
            else if (model.RandomData)
            {
                cities = TSPCreatorHelper.GenerateCity(30);
            }
            else
            {
                cities = DemoTSPData.Get();
            }

            if (algorithmType == TSPAlgorithm.GeneticAlgorithm)
            {
                algorithm = new GeneticAlgorithm(
                    model.MutatorValue,
                    model.GenerationCount,
                    model.PopulationSize,
                    crossoverType,
                    selectionType,
                    cities);
            }
            else if (algorithmType == TSPAlgorithm.SimulatedAnnealing)
            {
                algorithm = new SimulatedAnnealing(
                    model.Temperature,
                    model.CoolingRate,
                    model.Number,
                    cities);
            }
            else
            {
                throw new Exception();
            }

            algorithm.Execute();

            var result = new TSPResultViewModel()
            {
                Result = algorithm.GetResult(),
                Cities = TourManager.Cities
            };

            return View(result);
        }
    }
}