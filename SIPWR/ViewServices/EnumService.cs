using SIPWR.Hanoi;
using SIPWR.TSP;
using SIPWR.TSP.Crossover;
using SIPWR.TSP.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SIPWR.ViewServices
{
    public class EnumService
    {
        public IEnumerable<SelectListItem> GetSelectionTypes()
        {
            var enums = Enum.GetNames(typeof(SelectionType))
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() });

            return enums;
        }

        public IEnumerable<SelectListItem> GetCrossoverTypes()
        {
            var enums = Enum.GetNames(typeof(CrossoverType))
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() });

            return enums;
        }

        public IEnumerable<SelectListItem> GetTSPAlgorithmTypes()
        {
            var enums = Enum.GetNames(typeof(TSPAlgorithm))
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() });

            return enums;
        }

        public IEnumerable<SelectListItem> GetHanoiAlgorithmTypes()
        {
            var enums = Enum.GetNames(typeof(HanoiAlgorithm))
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() });

            return enums;
        }
    }
}