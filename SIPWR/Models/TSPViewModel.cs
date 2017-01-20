using SIPWR.TSP.Crossover;
using SIPWR.TSP.Model;
using SIPWR.TSP.Selection;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIPWR.Models
{
    public class TSPViewModel
    {
        public IEnumerable<SelectListItem> TSPAlgorithms { get; set; }

        public string SelectedPosition { get; set; }

        public double CoolingRate { get; set; }

        public double Temperature { get; set; }

        public int Number { get; set; }

        public int MutatorValue { get; set; }

        public int GenerationCount { get; set; }

        public int PopulationSize { get; set; }

        public IEnumerable<SelectListItem> CrossoverTypes { get; set; }

        public string SelectedCrossoverPosition { get; set; }

        public IEnumerable<SelectListItem> SelectionTypes { get; set; }

        public string SelectedSelectionPosition { get; set; }

        public string Cities { get; set; }

        public bool RandomData { get; set; }

        public int GenerateCityNumber { get; set; }

        public bool DemoData { get; set; }
    }
}